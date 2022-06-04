using Dapper;
using Npgsql;
using PetitAmourAPI.Domain.Requests;

namespace PetitAmourAPI.Database.Repositories;

public class ClosedDateRepository : IDisposable
{
    private readonly DbContext _dbContext;

    public ClosedDateRepository(DbContext dbContext)
        => _dbContext = dbContext;

    internal async Task<IEnumerable<DateTime>> GetAllClosedDates()
    {
        var connection = await _dbContext.GetConnection();

        return await connection.QueryAsync<DateTime>("SELECT * FROM \"ClosedDate\";");
    }

    internal async Task<(bool, string)> Insert(DateRequest closedDate)
    {
        var commandText = "INSERT INTO \"ClosedDate\" (\"Date\") VALUES (@Date);";

        try
        {
            var queryArguments = new
            {
                Date = new DateTime(closedDate.Year, closedDate.Month, closedDate.Day)
            };

            var connection = await _dbContext.GetConnection();

            await connection.ExecuteAsync(commandText, queryArguments);
        }
        catch (PostgresException ex)
        {
            if (ex.SqlState is "23505")
                return (false, "A data selecionada já está fechada");

            throw;
        }
        catch (Exception)
        {
            return (false, "Ocorreu um erro ao tentar fechar uma data");
        }

        return (true, string.Empty);
    }

    internal async Task<(bool, string)> Delete(DateRequest closedDate)
    {
        var commandText = "DELETE FROM \"ClosedDate\" WHERE \"Date\" = @Date;";

        try
        {
            var queryArguments = new
            {
                Date = new DateTime(closedDate.Year, closedDate.Month, closedDate.Day)
            };

            var connection = await _dbContext.GetConnection();

            var numberOfDeletedRows = await connection.ExecuteAsync(commandText, queryArguments);

            if (numberOfDeletedRows is 0)
                return (false, "A data selecionada já está livre");
        }
        catch (Exception)
        {
            return (false, "Ocorreu um erro ao tentar liberar a data");
        }

        return (true, string.Empty);
    }

    public void Dispose() => _dbContext.Dispose();
}