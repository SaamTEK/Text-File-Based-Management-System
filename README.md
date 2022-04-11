## Phase-1 Project: Text-file Based Management System 

**Problem Statement**: Create a Text-file Based System for Storing and Updating Teacher records. 
**Description:** Write a program that will allow storing and updating teacher data using text files.  

**Requirements**:  

- Must be a **Visual Studio Windows Console Project** 

**Class Format**:  

- Should store the following data for a teacher record: 
  - **ID** 
  - **Name** 
  - **Class & Section** 

**Solution:** For the above problem statement, the solution has been designed in a way which abides by the objected oriented programming (OOP) paradigm which includes the demonstration of OOP principles such as Data Encapsulation, Data Abstraction, Code Reusability, etc. 

The solution is designed with three classes which include: 

- Program class (Main Function): 
  - It is responsible for executing the program and displaying the main menu options for user interaction with the software. 
- Teacher class (Model and View): 
  - This class is responsible for coordinating with the Store Controller to process the data and store the data for persistence. 
  - This class contains the problem logic for performing Create, Read, Update and Delete (CRUD) operations for storing a teacher record. 
  - This class is also responsible for displaying the results to the user. 
  
- StoreController class (Controller): 
  - This class acts as a driver for interfacing with the file which stores the data acting as a database. 
  - This class initializes a “Data Store” text file in the filesystem which contains all the records. 
  - This class contains methods for Reading and Modifying the “Data Store” which includes Saving Data, Retrieving Data – All Data, Filtered Data, Data at an Index, Updating Data and Deleting Data. 

**Some Features of the Software**: 

- The records stored in the “Data Store” is in the Comma Separated Values (CSV) format, which therefore can be easily exported as .csv file for further analysis, etc. 

- The software performs basic user input validations in the following inputs: 
  - The GetInput(string Prompt) function is used to obtain user input which checks if the input is empty or contains an illegal character (,) upon which it returns an Invalid Input Error message and asks the user to re-enter the input until the checks are passed. 
  - The GetInput(string Prompt , string PrevValue) overloaded function is used when updating teacher record which allows empty input and treats it as “No modify” which means the previous value of a particular field will remain as is and only required fields can be updated. 
  - The GetIndexInput(string Prompt) function is used when taking in user input for the index of the teacher record to Update or Delete. This function validates that the entered index value is within range of the total number of records. 

- The software provides feedback to the user after any of the Create, Read, Update or Delete operation is performed: 
  - The GetAllTeachers() function returns a table with all the teacher records. 
  - The AddNewTeacher() function takes in user input for ID, Name and Class&Section of the Teacher record and displays the entire table back after successful insertion. 
  - The FilterTeachers() function takes In user input for the filter parameters (ID, Name or Class&Section) and returns a table of the filtered teacher records. 
  - The UpdateTeacher() function takes in user input to select a teacher record to update using index value, upon selecting, the selected teacher’s row is returned as a table to show the user which teacher record is being modified. After which it takes user input to update any or none of the fields of the teacher record and returns the entire table back with the updated record. 
  - The DeleteTeacher() function takes in user input to select a teacher record to delete using index value, upon selecting, the selected teacher’s row is returned as a table to show the user which teacher record is deleted. It also returns the entire table back to provide feedback about the status of deletion to the user. 

---

M, Saathvik | TEXT-FILE BASED MANAGEMENT SYSTEM
