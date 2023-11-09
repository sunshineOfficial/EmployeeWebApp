CREATE TABLE public."Companies"
(
    "Id" integer NOT NULL GENERATED ALWAYS AS IDENTITY,
    "Name" character varying(50)[] NOT NULL,
    PRIMARY KEY ("Id")
);

CREATE TABLE public."Passports"
(
    "Id" integer NOT NULL GENERATED ALWAYS AS IDENTITY,
    "Type" character varying(50)[] NOT NULL,
    "Number" character varying(50)[] NOT NULL,
    PRIMARY KEY ("Id")
);

CREATE TABLE public."Departments"
(
    "Id" integer NOT NULL GENERATED ALWAYS AS IDENTITY,
    "Name" character varying(50)[] NOT NULL,
    "Phone" character varying(20)[] NOT NULL,
    PRIMARY KEY ("Id")
);

CREATE TABLE public."Employees"
(
    "Id" integer NOT NULL GENERATED ALWAYS AS IDENTITY,
    "Name" character varying(50)[] NOT NULL,
    "Surname" character varying(50)[] NOT NULL,
    "Phone" character varying(20)[] NOT NULL,
    "CompanyId" integer NOT NULL references "Companies"("Id"),
    "PassportId" integer NOT NULL references "Passports"("Id"),
    "DepartmentId" integer NOT NULL references "Departments"("Id"),
    PRIMARY KEY ("Id")
);