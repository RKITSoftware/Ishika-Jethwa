using ServiceStack.OrmLite;

namespace ORMDemo
{
    /// <summary>
    /// class tablemanagement for representing ormservice
    /// </summary>
    public class BLTableManagement
    {
        /// <summary>
        /// Creates a table for the specified type <typeparamref name="T"/> if it does not already exist.
        /// </summary>
        public string CreateTable<T>()
        {
            using (var db = Connections.dbFactory.OpenDbConnection())
            {
                if (db.TableExists<T>())
                {
                    return ($"Table '{typeof(T).Name}' already exists.");
                }
                else
                {
                    db.CreateTable<T>();
                    return ($"Table '{typeof(T).Name}' created successfully.");
                }
            }
        }

        /// <summary>
        /// Drops a table for the specified type <typeparamref name="T"/> if it exists.
        /// </summary>
        /// <typeparam name="T">The type representing the table.</typeparam>
        public string DropTable<T>()
        {
            using (var db = Connections.dbFactory.OpenDbConnection())
            {
                if (db.TableExists<T>())
                {
                    db.DropTable<T>();
                    return ($"Table '{typeof(T).Name}' dropped successfully.");
                }
                else
                {
                    return ($"Table '{typeof(T).Name}' does not exist.");
                }
            }
        }

        /// <summary>
        /// Alters a table for the specified type <typeparamref name="T"/> by adding a new column.
        /// </summary>
        /// <typeparam name="T">The type representing the table.</typeparam>
        /// <param name="columnName">The name of the new column to add.</param>
        /// <param name="columnType">The data type of the new column.</param>
        public string AlterTableAddColumn<T>(string columnName, string columnType)
        {
            using (var db = Connections.dbFactory.OpenDbConnection())
            {
                if (db.TableExists<T>())
                {
                    db.ExecuteSql($"ALTER TABLE {db.GetTableName<T>()} ADD COLUMN {columnName} {columnType}");
                        return ($"Column '{columnName}' added to table '{typeof(T).Name}' successfully.");
                }
                else
                {
                    return ($"Table '{typeof(T).Name}' does not exist.");
                }
            }
        }
    }
}
