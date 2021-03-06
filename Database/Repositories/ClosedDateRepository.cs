using Dapper;
using Npgsql;

namespace PetitAmourAPI.Database.Repositories;

public class ClosedDateRepository : IDisposable
{
    private readonly DatabaseConnection _databaseConnection;

    public ClosedDateRepository(DatabaseConnection database)
        => _databaseConnection = database;

    internal async Task<IEnumerable<DateTime>> AllClosedDates()
    {
        var connection = _databaseConnection.Get();

        return await connection.QueryAsync<DateTime>("SELECT * FROM closed_date;");
    }

    internal async Task<bool> Date(DateTime date)
    {
        var connection = _databaseConnection.Get();

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
            var connection = _databaseConnection.Get();

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
            var connection = _databaseConnection.Get();

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

    public void Dispose() => _databaseConnection.Dispose();
}