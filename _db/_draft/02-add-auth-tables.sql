DO $$
BEGIN

-- users
IF NOT EXISTS (SELECT 1 FROM pg_tables WHERE schemaname = 'public' AND tablename = 'user') THEN
CREATE TABLE public.user (
    user_id UUID PRIMARY KEY,
    user_name TEXT NOT NULL,
    normalized_user_name TEXT NOT NULL,
    email TEXT NOT NULL,
    normalized_email TEXT NOT NULL,
    email_confirmed BOOLEAN NOT NULL,
    password_hash TEXT,
    security_stamp UUID,
    concurrency_stamp UUID NOT NULL,
    phone_number TEXT,
    phone_number_confirmed BOOLEAN NOT NULL,
    two_factor_enabled BOOLEAN NOT NULL,
    lockout_end TIMESTAMP WITH TIME ZONE,
    lockout_enabled BOOLEAN NOT NULL,
    access_failed_count INTEGER NOT NULL DEFAULT 0,
    profile_picture_media_id UUID,
    created_at TIMESTAMP DEFAULT NOW() NOT NULL,
    modified_at TIMESTAMP DEFAULT NOW() NOT NULL,
    status INTEGER NOT NULL
);
END IF;

-- role
IF NOT EXISTS (SELECT FROM pg_tables WHERE schemaname = 'public' AND tablename = 'role') THEN
CREATE TABLE public.role (
    role_id UUID PRIMARY KEY,
    name TEXT NOT NULL,
    normalized_name TEXT NOT NULL,
    concurrency_stamp UUID NOT NULL
);
END IF;

-- claim
IF NOT EXISTS (SELECT FROM pg_tables WHERE schemaname = 'public' AND tablename = 'claim') THEN
CREATE TABLE public.claim (
    claim_id UUID PRIMARY KEY,
    role_id UUID NOT NULL,
    type TEXT NOT NULL,
    value TEXT NOT NULL,
    FOREIGN KEY (role_id) REFERENCES public.role(role_id) ON DELETE CASCADE
);
END IF;

-- user_role
IF NOT EXISTS (SELECT FROM pg_tables WHERE schemaname = 'public' AND tablename = 'user_role') THEN
CREATE TABLE public.user_role (
    user_id UUID NOT NULL,
    role_id UUID NOT NULL,
    PRIMARY KEY (user_id, role_id),
    FOREIGN KEY (user_id) REFERENCES public.user (user_id) ON DELETE CASCADE,
    FOREIGN KEY (role_id) REFERENCES public.role (role_id) ON DELETE CASCADE
);
END IF;

END $$;
