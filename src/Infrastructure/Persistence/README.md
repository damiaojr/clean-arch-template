# Persistence

Persistence of data refers to the ability of data to persist, or remain, beyond the lifetime of the application or program that created it. In other words, the data is stored permanently in a way that it can be accessed and used by other applications or users even after the original application has terminated or the computer has been shut down.

In software development, persistence of data is a crucial aspect of creating robust applications. It allows data to be stored and retrieved over time, enabling users to save information, access it later, and share it with others. Data persistence is achieved through the use of various mechanisms such as files, databases, cloud storage, and other forms of data storage.

## The DbContext

In Entity Framework, the Database Context is a class that represents a session with the database and provides an entry point to access and manipulate data stored in the database. It acts as a bridge between the domain classes (CLR objects) and the underlying database.

The Database Context contains DbSet properties that correspond to database tables, and each DbSet property exposes methods that allow querying, adding, modifying, and deleting data in the corresponding table.

When an application uses Entity Framework to access a database, it typically creates an instance of a Database Context class that corresponds to that database. The application then uses this instance to perform operations on the database, such as reading data, updating data, or executing stored procedures.

The Database Context also manages the connection to the database, and by default, Entity Framework will open a new connection to the database for each instance of the Database Context. However, the application can configure the Database Context to reuse connections or to use a connection pool for better performance.

*In this project, the Database Context class is responsible to dispatch Domain Events.*