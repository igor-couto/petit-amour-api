using Dapper;
using Npgsql;

namespace PetitAmourAPI.Database.Repositories;

public class ClosedDateRepository : IDisposable
{
    private readonly Database _database;

    public ClosedDateRepository(Database database)
        => _database = database;

    internal async Task<IEnumerable<DateTime>> GetAllClosedDates()
    {
        var connection = await _database.GetConnection();

        return await connection.QueryAsync<DateTime>("SELECT * FROM closed_date;");
    }

    internal async Task<bool> GetDate(DateTime date)
    {
        var connection = await _database.GetConnection();

        var result = await connection.QuerySingleOrDefaultAsync("SELECT * FROM closed_date WHERE date = @date;", new { date });

        if (result is null)
            return false;
        else
            return true;
    }

    internal async Task<(bool, string)> Insert(DateTime date)
    {
        var commandText = "INSERT INTO closed_date (date) VALUES (@date);";

        try
        {
            var connection = await _database.GetConnection();

            await connection.ExecuteAsync(commandText, date);
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

    internal async Task<(bool, string)> Delete(DateTime date)
    {
        var commandText = "DELETE FROM closed_date WHERE date = @date;";

        try
        {
            var connection = await _database.GetConnection();

            var numberOfDeletedRows = await connection.ExecuteAsync(commandText, date);

            if (numberOfDeletedRows is 0)
                return (false, "A data selecionada já está livre");
        }
        catch (Exception)
        {
            return (false, "Ocorreu um erro ao tentar liberar a data");
        }

        return (true, string.Empty);
    }

    public void Dispose() => _database.Dispose();
}