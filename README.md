# WebScraper

---

## Web Scraper Console Application in C#

### Overview

This console application serves as a basic web scraper written in C#. It allows users to input a website URL, and then it extracts and downloads PDF files linked on the specified webpage.

### Features

1. **User Input:**
   - The application prompts the user to enter the URL of a website.

2. **HTML Parsing:**
   - Utilizes the `HtmlAgilityPack` library to parse HTML content and extract links from the provided webpage.

3. **PDF Download:**
   - Identifies links pointing to PDF files on the webpage.
   - Downloads the identified PDF files to a local directory.

4. **Handling 404 Errors:**
   - Handles `WebException` to check if a downloaded file results in a 404 error (File Not Found).

5. **User Interaction:**
   - Notifies the user when the PDF downloads are completed.
   - Prompts the user to press any key to exit the application.

### How to Use

1. **Run the Application:**
   - Execute the console application.
   
2. **Enter Website URL:**
   - Enter the URL of the website when prompted.

3. **Downloaded PDFs:**
   - The application will download PDF files linked on the webpage to a folder named "Downloads" in the application directory.

4. **Exit Application:**
   - After downloads are complete, the user is prompted to press any key to exit the application.

### Technologies and Utilities Used

- **C# Language:**
  - The application is written in C# for the .NET Framework.

- **HtmlAgilityPack:**
  - Used for HTML parsing to extract links from the webpage.

- **WebClient Class:**
  - Utilized for making HTTP requests and downloading files.

- **Console Class:**
  - Used for user interaction and displaying messages in the console.

- **Path and Directory Classes:**
  - Used for handling file paths and creating directories.

---
