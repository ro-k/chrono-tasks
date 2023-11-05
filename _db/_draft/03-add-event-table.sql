DO $$
BEGIN

IF NOT EXISTS (SELECT 1 FROM pg_tables WHERE schemaname = 'public' AND tablename = 'events') THEN
CREATE TABLE public.events (
    event_id UUID PRIMARY KEY,
    start_time TIMESTAMP NOT NULL,
    end_time TIMESTAMP NOT NULL,
    name TEXT NOT NULL,
    description TEXT,
    created_at TIMESTAMP NOT NULL DEFAULT NOW(),
    modified_at TIMESTAMP NOT NULL DEFAULT NOW(),
    user_id UUID NOT NULL,
    concurrency_stamp UUID NOT NULL DEFAULT gen_random_uuid()
);
END IF;

IF NOT EXISTS (SELECT 1 FROM pg_tables WHERE schemaname = 'public' AND tablename = 'media') THEN
CREATE TABLE public.media (
    media_id UUID PRIMARY KEY,
    category_id UUID NOT NULL,
    event_id UUID,
    job_id UUID,
    original_filename VARCHAR NOT NULL,
    extension VARCHAR NOT NULL,
    mime_type VARCHAR NOT NULL,
    size BIGINT NOT NULL,
    storage_path VARCHAR NOT NULL,
    hash VARCHAR NOT NULL,
    metadata TEXT,
    status INTEGER NOT NULL,
    created_at TIMESTAMP NOT NULL DEFAULT NOW(),
    modified_at TIMESTAMP NOT NULL DEFAULT NOW(),
    user_id UUID NOT NULL,
    concurrency_stamp UUID NOT NULL DEFAULT gen_random_uuid()
);
END IF;

END $$;
