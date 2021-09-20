BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "myCalendar" (
	"id"	INTEGER,
	"eventDate"	TEXT,
	"eventName"	TEXT,
	PRIMARY KEY("id")
);
INSERT INTO "myCalendar" VALUES (1,'2021-10-01','Starting work as a Test Engineer 1');
INSERT INTO "myCalendar" VALUES (2,'2021-09-26','Initial date for the presentation of the Internship Program');
INSERT INTO "myCalendar" VALUES (3,'2021-09-26','Business Meeting');
INSERT INTO "myCalendar" VALUES (4,'2021-10-09','BHP training');
INSERT INTO "myCalendar" VALUES (5,'2021-10-01','Onboarding program start');
INSERT INTO "myCalendar" VALUES (6,'2021-10-05','Innovation week');
INSERT INTO "myCalendar" VALUES (7,'2021-09-30','End of Internship program');
INSERT INTO "myCalendar" VALUES (8,'2021-09-21','Sprint review');
INSERT INTO "myCalendar" VALUES (9,'2021-09-24','Leave work early');
INSERT INTO "myCalendar" VALUES (10,'2021-09-24','Send a signed employment contract');
INSERT INTO "myCalendar" VALUES (11,'2021-09-24','Medical exams');
INSERT INTO "myCalendar" VALUES (12,'2021-10-21','Retrospective');
INSERT INTO "myCalendar" VALUES (13,'2021-09-17','Add menu to the myCalendar project');
INSERT INTO "myCalendar" VALUES (14,'2021-09-20','Finished project - myCalendar in C#');
INSERT INTO "myCalendar" VALUES (15,'2021-09-14','Build myCalendar app');
INSERT INTO "myCalendar" VALUES (16,'2021-10-08','Connect database with the myCalendar application');
INSERT INTO "myCalendar" VALUES (17,'2021-09-20','Code Reviev myCalendar app');
COMMIT;
