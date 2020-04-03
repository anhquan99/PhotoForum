# PhotoForum
requirement : 
  -visual studio
  -.net framework 4.5
  -Entity framework
  -MS SQL server
This project is using:
  -Entity Framework so devs will not upload entities is get from this framework
  -COMMAND PATTERN
STEP:
  1. EXECUTE DATABASE FILE IN DATABASE.SQL
  2. CREATE NEW ASP.NET WEB APPLICATION(.NET FRAMEWORK) IN VISUAL STUDIO GO WITH WEB API
  3. IN MODELS FOLDER OF PROJECT CREATE FOLDER DB. ADD ADO NET ENTITY DATA MODEL WITH NAME = "PhotoModel" CHOOSE 4 TABLE:
    +IMG
    +PHOTO_USER
    +TAG
    +TAG_IMG
AND 2 STORE PROCUDURE:
    +SELECT_NEWEST_IMG
    +FIND_IMG_WITH_TAG
  4. COPY ALL FOLDER TO PROJECT FOLDER
