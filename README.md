USE THIS SQL TO Create DB AND TABLE:

-- Database: ConstructionDB

-- DROP DATABASE IF EXISTS "ConstructionDB";

CREATE DATABASE "ConstructionDB"
    WITH
    OWNER = postgres
    ENCODING = 'UTF8'
    LC_COLLATE = 'en-US'
    LC_CTYPE = 'en-US'
    LOCALE_PROVIDER = 'libc'
    TABLESPACE = pg_default
    CONNECTION LIMIT = -1
    IS_TEMPLATE = False;

CREATE TABLE "Users" (
    "Id" UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    "Email" VARCHAR(255) NOT NULL UNIQUE,
    "Password" VARCHAR(255) NOT NULL
);

CREATE TABLE "ConstructionProjects" (
    "ProjectId" SERIAL PRIMARY KEY,
    "ProjectName" VARCHAR(200) NOT NULL,
    "ProjectLocation" VARCHAR(500) NOT NULL,
    "ProjectStage" VARCHAR(50) NOT NULL CHECK ("ProjectStage" IN ('Concept', 'Design & Documentation', 'Pre-Construction', 'Construction')),
    "ProjectCategory" VARCHAR(100) NOT NULL,
    "ConstructionStartDate" timestamp NOT NULL,
    "ProjectDetails" TEXT NOT NULL,
    "CreatorId" UUID NOT NULL REFERENCES "Users"("Id") ON DELETE CASCADE
);

CREATE INDEX "idx_project_stage" ON "ConstructionProjects"("ProjectStage");
CREATE INDEX "idx_project_category" ON "ConstructionProjects"("ProjectCategory");
