--Drop DB if present
--DROP DATABASE InventoryMS;

-- Create the database
CREATE DATABASE InventoryMS;

-- Use the database
USE InventoryMS;

-- Create the Categories table
CREATE TABLE Categories (
    CategoryID INT IDENTITY(1,1) PRIMARY KEY,
    CategoryName NVARCHAR(255) NOT NULL,
    Description TEXT
);

-- Create the Suppliers table
CREATE TABLE Suppliers (
    SupplierID INT IDENTITY(1,1) PRIMARY KEY,
    SupplierName NVARCHAR(255) NOT NULL,
    ContactName NVARCHAR(255),
    Address NVARCHAR(255),
    City NVARCHAR(255),
    PostalCode NVARCHAR(20),
    Country NVARCHAR(255),
    Phone NVARCHAR(50),
    Email NVARCHAR(255)
);

-- Create the Products table
CREATE TABLE Products (
    ProductID INT IDENTITY(1,1) PRIMARY KEY,
    ProductName NVARCHAR(255) NOT NULL,
    CategoryID INT,
    SupplierID INT,
    QuantityPerUnit NVARCHAR(255),
    UnitPrice DECIMAL(10, 2),
    UnitsInStock INT,
    UnitsOnOrder INT,
    ReorderLevel INT,
    Discontinued BIT,
    FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID),
    FOREIGN KEY (SupplierID) REFERENCES Suppliers(SupplierID)
);

-- Create the ProductDetails table
CREATE TABLE ProductDetails (
    ProductDetailID INT IDENTITY(1,1) PRIMARY KEY,
    ProductID INT,
    Description NVARCHAR(MAX),
    Specifications NVARCHAR(MAX),
    WarrantyPeriod NVARCHAR(50),
    Manufacturer NVARCHAR(255),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- Create the ProductInventory table
CREATE TABLE ProductInventory (
    InventoryID INT IDENTITY(1,1) PRIMARY KEY,
    ProductID INT,
    Location NVARCHAR(255),
    Quantity INT,
    LastUpdated DATE,
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);
