# DVLD (Driving & Vehicle License Management System)

# System Requirements Document

## Table of Contents
1. [Overview](#overview)
2. [Core Services and Requirements](#Core-Services-and-Requirements)
3. [Features](#Features)
4. [Document and Test Requirements](#Document-and-Test-Requirements)
5. [Architecture](#Architecture)
6. [Application Features](#Application-Features)


---

### Overview
This project outlines the requirements for a system that manages people, requests, tests, license categories , and license reservations. Each section describes specific functionality, data requirements, and rules for managing entities within the system.

---

## Core-Services-and-Requirements 
### New License Issuance

Initial license applications for specific categories (e.g., motorcycle, regular car, commercial).
Requirements include minimum age, fee per category, and completion of medical, theoretical, and practical tests.
License details: validity period, license category, issuance and expiration dates, and associated fees.
Additional checks ensure the applicant does not already hold a license in the requested category.
### Re-Test Service

Allows applicants to schedule a new test date if they previously failed.
Requires additional fees and is tied to the original application.
Only one test can be scheduled at a time for each type (vision, theoretical, or practical).
### License Renewal

Applicable when a license reaches its expiration.
Requires a vision test and submission of the expired license.
Includes a renewal fee.
Replacement for Lost/Damaged License

Allows issuing a replacement for a lost or damaged license.
System checks if the license is under restriction.
Requires submission of the damaged license (if applicable) and an additional fee.
### License Reinstatement

Enables the release of a license that was previously suspended.
Requires payment of a fine and records the date of reinstatement.
International License Issuance

Available only to holders of a valid Class 3 (regular car) license.
Includes a separate fee and requires the national license to be in good standing (not expired or suspended).
A new international license cannot be issued if a valid one already exists.
Applicant and Licensee Information Management
### Applicant Information

Stores personal details, including national ID, name, birthdate, address, phone, email, nationality, and profile picture.
Only one unique record per applicant in the system, used for all subsequent applications and licenses.
### License Classes

Each license category has specific requirements such as minimum age, validity duration, and fees.
System ensures compliance with age and prior license conditions for each class.
### Document-and-Test-Requirements

#### Vision Test: Medical examination to check visual acuity; fee applies, and results must be recorded.
#### Theoretical Exam: Covers traffic laws and safety; fee applies, scored out of 100.
#### Practical Exam: Tests vehicle handling and rule compliance; fee varies by license category.
System Administration
### User Management

Ability to add, view, modify, delete, or suspend user accounts.
Assign roles and permissions to control system access.
### Person Management

Search and manage individuals in the system using their national ID.
Supports integration with other services for additional verification.
Inquiries

Enables lookup of licenses held by individuals based on national ID or license number.
## Architecture
This License Management System was developed with a **3-tier architecture** to ensure modularity, scalability, and maintainability. The layers include:

1. **Presentation Layer**  
   - Handles user interaction and UI logic.
   - Developed using WinForms for a desktop application or ASP.NET for web-based interaction.
  
2. **Business Logic Layer (BLL)**  
   - Processes data between the presentation layer and the data access layer.
   - Contains the core business logic to ensure the integrity and accuracy of transactions.

3. **Data Access Layer (DAL)**  
   - Directly communicates with the SQL Server database.
   - Handles data retrieval, storage, and modifications through T-SQL and stored procedures.
   - Implements secure connections and encryption for data transactions, enhancing data protection.

### Related Skills
- **T-SQL**: Used to efficiently manage complex queries and optimize database interactions. Benefits of T-SQL include improved data handling, enhanced security features, and robust transaction management.
- **Stored Procedures**: Enables efficient data handling and reduces redundancy in SQL code. Stored procedures improve performance and increase security by centralizing and encapsulating SQL operations.
- **Encryption**: Applied to the logging system, ensuring sensitive information (such as user actions and authentication details) is securely stored.

## Data Management
All data operations are managed with a focus on data consistency, security, and performance. Unique constraints, referential integrity, and optimized indexing are applied to ensure smooth and reliable data operations. The logging system additionally includes encrypted entries to safeguard user activity records.


## Usage
1. Launch the application and authenticate with  next credentials username : Msaqr77 password : 1234 .
2. Use the interface to manage individuals, requests, exams, licenses, and view logs.

## Application Features
- **Person Management**: Add, edit, view, and delete person records.
- **Request Management**: Handle different request types, including price information.
- **Test Management**: Modify test prices for predefined tests.
- **License Category Management**: Update license categories, including age requirements and fees.
- **License Reservation**: Reserve licenses with specific identifiers, fines, and reservation dates.
- **System Logging**: Log every action with user and date information for audit purposes.

## System Requirements
- **Database**: SQL Server 
- **Languages**: .NET Framework for backend

## Installation
1. **Clone the repository**:
   ```bash
   git clone https://github.com/soufi-43/DVLD.git
