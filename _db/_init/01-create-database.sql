DO $$
    BEGIN
        IF NOT EXISTS (
            SELECT datname
            FROM pg_catalog.pg_database
            WHERE datname = 'taskdb'
        )
        THEN
            CREATE DATABASE TaskDB;
        END IF;
    END
$$;
