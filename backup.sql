--
-- PostgreSQL database dump
--

-- Dumped from database version 17.2 (Debian 17.2-1.pgdg120+1)
-- Dumped by pg_dump version 17.2 (Debian 17.2-1.pgdg120+1)

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: Disciplines; Type: TABLE; Schema: public; Owner: maxim
--

CREATE TABLE public."Disciplines" (
    id uuid NOT NULL,
    "Name" text NOT NULL,
    "idTeacher" uuid NOT NULL,
    "idGroups" uuid[] NOT NULL
);


ALTER TABLE public."Disciplines" OWNER TO maxim;

--
-- Name: Groups; Type: TABLE; Schema: public; Owner: maxim
--

CREATE TABLE public."Groups" (
    id uuid NOT NULL,
    "Name" text NOT NULL,
    "id_Students" uuid[] NOT NULL
);


ALTER TABLE public."Groups" OWNER TO maxim;

--
-- Name: Students; Type: TABLE; Schema: public; Owner: maxim
--

CREATE TABLE public."Students" (
    id uuid NOT NULL,
    "Name" text NOT NULL,
    "SecondName" text NOT NULL,
    "GroupName" text NOT NULL,
    "IndividualNumber" numeric(20,0) NOT NULL,
    "Password" text NOT NULL
);


ALTER TABLE public."Students" OWNER TO maxim;

--
-- Name: Tasks; Type: TABLE; Schema: public; Owner: maxim
--

CREATE TABLE public."Tasks" (
    id uuid NOT NULL,
    "DateCreate" timestamp with time zone NOT NULL,
    "DateFinish" timestamp with time zone NOT NULL,
    "Description" text NOT NULL,
    "idDiscipline" uuid NOT NULL,
    "idGroup" uuid NOT NULL,
    "idTeacher" uuid NOT NULL
);


ALTER TABLE public."Tasks" OWNER TO maxim;

--
-- Name: Teachers; Type: TABLE; Schema: public; Owner: maxim
--

CREATE TABLE public."Teachers" (
    id uuid NOT NULL,
    "Name" text NOT NULL,
    "SecondName" text NOT NULL,
    "IndividualNumber" numeric(20,0) NOT NULL,
    "Password" text NOT NULL
);


ALTER TABLE public."Teachers" OWNER TO maxim;

--
-- Name: __EFMigrationsHistory; Type: TABLE; Schema: public; Owner: maxim
--

CREATE TABLE public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);


ALTER TABLE public."__EFMigrationsHistory" OWNER TO maxim;

--
-- Data for Name: Disciplines; Type: TABLE DATA; Schema: public; Owner: maxim
--

COPY public."Disciplines" (id, "Name", "idTeacher", "idGroups") FROM stdin;
43906eb5-7190-4df0-80c5-b616011973e3	Web	1963503a-da61-4d7a-b847-e51333ad832b	{39cb701e-bb8d-486c-aa0b-e6a34b94aca8}
\.


--
-- Data for Name: Groups; Type: TABLE DATA; Schema: public; Owner: maxim
--

COPY public."Groups" (id, "Name", "id_Students") FROM stdin;
39cb701e-bb8d-486c-aa0b-e6a34b94aca8	aa-21-07	{74cb4c4c-274d-43d4-b806-30a88636eaa0}
\.


--
-- Data for Name: Students; Type: TABLE DATA; Schema: public; Owner: maxim
--

COPY public."Students" (id, "Name", "SecondName", "GroupName", "IndividualNumber", "Password") FROM stdin;
74cb4c4c-274d-43d4-b806-30a88636eaa0	Maxim	Syuzev	aa-21-07	135616	1234
\.


--
-- Data for Name: Tasks; Type: TABLE DATA; Schema: public; Owner: maxim
--

COPY public."Tasks" (id, "DateCreate", "DateFinish", "Description", "idDiscipline", "idGroup", "idTeacher") FROM stdin;
eff14dc4-87ed-4929-9cd0-76e42da2f62f	2024-12-23 16:02:45.500875+00	2024-12-23 17:01:54.197+00	fwefwefwef	43906eb5-7190-4df0-80c5-b616011973e3	39cb701e-bb8d-486c-aa0b-e6a34b94aca8	43906eb5-7190-4df0-80c5-b616011973e3
bc9fd614-d13c-4f4e-b5b9-b35547fa8820	2024-12-23 17:11:14.371642+00	2024-12-23 17:01:54.197+00	ergergergerg	43906eb5-7190-4df0-80c5-b616011973e3	39cb701e-bb8d-486c-aa0b-e6a34b94aca8	43906eb5-7190-4df0-80c5-b616011973e3
cf500244-6d91-4b29-98c3-e87304fed643	2024-12-23 17:02:43.153215+00	2024-12-23 17:01:54.197+00	efrgergerge	43906eb5-7190-4df0-80c5-b616011973e3	39cb701e-bb8d-486c-aa0b-e6a34b94aca8	43906eb5-7190-4df0-80c5-b616011973e3
3e457857-fb4a-42e5-b644-73c9c341b759	2024-12-23 17:39:12.562875+00	2024-12-23 17:01:54.197+00	3rf34f3fwsdcwe	43906eb5-7190-4df0-80c5-b616011973e3	39cb701e-bb8d-486c-aa0b-e6a34b94aca8	1963503a-da61-4d7a-b847-e51333ad832b
7798a05a-b433-4934-891b-cc127fdb0d90	2024-12-23 17:39:24.860324+00	2024-12-23 17:01:54.197+00	34f3fwefcvwefwe	43906eb5-7190-4df0-80c5-b616011973e3	39cb701e-bb8d-486c-aa0b-e6a34b94aca8	1963503a-da61-4d7a-b847-e51333ad832b
\.


--
-- Data for Name: Teachers; Type: TABLE DATA; Schema: public; Owner: maxim
--

COPY public."Teachers" (id, "Name", "SecondName", "IndividualNumber", "Password") FROM stdin;
1963503a-da61-4d7a-b847-e51333ad832b	Marina	Nikolaevna	123	123
\.


--
-- Data for Name: __EFMigrationsHistory; Type: TABLE DATA; Schema: public; Owner: maxim
--

COPY public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") FROM stdin;
20241119180736_InitialCreate	9.0.0
20241222210654_init2	9.0.0
\.


--
-- Name: Disciplines PK_Disciplines; Type: CONSTRAINT; Schema: public; Owner: maxim
--

ALTER TABLE ONLY public."Disciplines"
    ADD CONSTRAINT "PK_Disciplines" PRIMARY KEY (id);


--
-- Name: Groups PK_Groups; Type: CONSTRAINT; Schema: public; Owner: maxim
--

ALTER TABLE ONLY public."Groups"
    ADD CONSTRAINT "PK_Groups" PRIMARY KEY (id);


--
-- Name: Students PK_Students; Type: CONSTRAINT; Schema: public; Owner: maxim
--

ALTER TABLE ONLY public."Students"
    ADD CONSTRAINT "PK_Students" PRIMARY KEY (id);


--
-- Name: Tasks PK_Tasks; Type: CONSTRAINT; Schema: public; Owner: maxim
--

ALTER TABLE ONLY public."Tasks"
    ADD CONSTRAINT "PK_Tasks" PRIMARY KEY (id);


--
-- Name: Teachers PK_Teachers; Type: CONSTRAINT; Schema: public; Owner: maxim
--

ALTER TABLE ONLY public."Teachers"
    ADD CONSTRAINT "PK_Teachers" PRIMARY KEY (id);


--
-- Name: __EFMigrationsHistory PK___EFMigrationsHistory; Type: CONSTRAINT; Schema: public; Owner: maxim
--

ALTER TABLE ONLY public."__EFMigrationsHistory"
    ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");


--
-- PostgreSQL database dump complete
--

