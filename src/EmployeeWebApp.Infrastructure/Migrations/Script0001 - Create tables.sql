CREATE TABLE IF NOT EXISTS public."Companies"
(
    "Id" integer NOT NULL GENERATED ALWAYS AS IDENTITY,
    "Name" character varying(50) NOT NULL,
    PRIMARY KEY ("Id")
);

CREATE TABLE IF NOT EXISTS public."Passports"
(
    "Id" integer NOT NULL GENERATED ALWAYS AS IDENTITY,
    "Type" character varying(50) NOT NULL,
    "Number" character varying(50) NOT NULL,
    PRIMARY KEY ("Id")
);

CREATE TABLE IF NOT EXISTS public."Departments"
(
    "Id" integer NOT NULL GENERATED ALWAYS AS IDENTITY,
    "Name" character varying(50) NOT NULL,
    "Phone" character varying(20) NOT NULL,
    PRIMARY KEY ("Id")
);

CREATE TABLE IF NOT EXISTS public."Employees"
(
    "Id" integer NOT NULL GENERATED ALWAYS AS IDENTITY,
    "Name" character varying(50) NOT NULL,
    "Surname" character varying(50) NOT NULL,
    "Phone" character varying(20) NOT NULL,
    "CompanyId" integer NOT NULL references "Companies"("Id") ON DELETE CASCADE ON UPDATE CASCADE,
    "PassportId" integer NOT NULL references "Passports"("Id") ON DELETE CASCADE ON UPDATE CASCADE,
    "DepartmentId" integer NOT NULL references "Departments"("Id") ON DELETE CASCADE ON UPDATE CASCADE,
    PRIMARY KEY ("Id")
);