# DVLD (Driving & Vehicle License Management System)

# System Requirements Document

## Table of Contents
1. [Overview](#overview)
2. [Core Services and Requirements](#Core-Services-and-Requirements)
3. [Request Type Management](#request-type-management)
4. [Test Management](#test-management)
5. [License Category Management](#license-category-management)
6. [License Reservation](#license-reservation)
7. [System Logging](#system-logging)

---

### Overview
This document outlines the requirements for a system that manages people, requests, tests, license categories, and license reservations. Each section describes specific functionality, data requirements, and rules for managing entities within the system.

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
### Document and Test Requirements

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
## Features
- **Person Management**: Add, edit, view, and delete person records.
- **Request Management**: Handle different request types, including price information.
- **Test Management**: Modify test prices for predefined tests.
- **License Category Management**: Update license categories, including age requirements and fees.
- **License Reservation**: Reserve licenses with specific identifiers, fines, and reservation dates.
- **System Logging**: Log every action with user and date information for audit purposes.

## System Requirements
- **Operating System**: Windows, macOS, or Linux
- **Database**: SQL Server or compatible RDBMS
- **Languages**: .NET Framework for backend
- **Framework**: .NET 6 or higher

## Installation
1. **Clone the repository**:
   ```bash
   git clone https://github.com/soufi-43/DVLD.git
