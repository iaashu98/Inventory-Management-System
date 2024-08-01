--Sometimes due to bad seed product creation may see disruption. Please run the RESEED command to ensure the integrity
DBCC CHECKIDENT ('Categories', RESEED, 0);
DBCC CHECKIDENT ('Suppliers', RESEED, 0);
DBCC CHECKIDENT ('Products', RESEED, 0);
DBCC CHECKIDENT ('ProductDetails', RESEED, 0);
DBCC CHECKIDENT ('ProductInventory', RESEED, 0);

INSERT INTO Categories (CategoryName, Description)
VALUES 
('Beverages', 'Soft drinks, coffees, lassi, chai and juices'),
('Condiments', 'Sweet and savory sauces, relishes, spreads, and seasonings'),
('Confections', 'Desserts, candies, and sweet breads'),
('Dairy Products', 'Cheeses, paneers, curd, malai'),
('Grains/Cereals', 'Breads, museli, pasta, and cereal');
SELECT * from Categories

INSERT INTO Suppliers (SupplierName, ContactName, Address, City, PostalCode, Country, Phone, Email)
VALUES 
('Exotic Liquids', 'Ashutosh Ranjan', 'M.G Road', 'Bengaluru', '560037', 'India', '+91 971-555-2222', 'contactus@exoticliquids.com'),
('New Delhi Pastry Delights', 'Shruvi Sharma', '113, Connaught Place', 'New Delhi', '110001', 'India', '+91 888-555-4822', 'shruvi@ndpastrydelights.com'),
('Dadi Ki Mithai', 'Rohini Murty', 'Juhu Tara Rd, Juhu', 'Mumbai', '400049', 'India', '+91 999-555-5735', 'rohini@dadikimithai.com'),
('Patna Bites', 'Arush Krishna', 'S2, Boring Road', 'Patna', '800003', 'India', '+91 333-555-5011', 'arush@patnabites.com'),
('Kolkata Craving Corner', 'Anwesha Das', 'South City Mall Street', 'Kolkata', '700068', 'India', '+91 777-598-7654', 'anwesha@kcconer.com');
SELECT * from Suppliers

INSERT INTO Products (ProductName, CategoryID, SupplierID, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued)
VALUES 
('Chai', 1, 1, '10 boxes x 20 bags', 18.00, 39, 0, 10, 0),
('Chang', 1, 1, '24 - 12 oz bottles', 19.00, 17, 40, 25, 0),
('Aniseed Syrup', 2, 1, '12 - 550 ml bottles', 10.00, 13, 70, 25, 0),
('Chef Anton’s Cajun Seasoning', 2, 2, '48 - 6 oz jars', 22.00, 53, 0, 0, 0),
('Chef Anton’s Gumbo Mix', 2, 2, '36 boxes', 21.35, 0, 0, 0, 1),
('Grandma’s Boysenberry Spread', 2, 3, '12 - 8 oz jars', 25.00, 120, 0, 25, 0),
('Uncle Bob’s Organic Dried Pears', 3, 3, '12 - 1 lb pkgs.', 30.00, 15, 0, 10, 0),
('Northwoods Cranberry Sauce', 2, 3, '12 - 12 oz jars', 40.00, 6, 0, 0, 0),
('Mishi Kobe Niku', 4, 4, '18 - 500 g pkgs.', 97.00, 29, 0, 0, 1),
('Ikura', 5, 4, '12 - 200 ml jars', 31.00, 31, 0, 0, 0);
SELECT * from Products

INSERT INTO ProductDetails (ProductID, Description, Specifications, WarrantyPeriod, Manufacturer)
VALUES 
(1, 'A sweet and spicy blend of traditional Indian herbs and spices', '500g pack, Contains cardamom, cinnamon, cloves, black pepper', '6 months', 'Exotic Liquids'),
(2, 'A refreshing Chinese beer with a crisp taste', '24 bottles of 330ml each', '6 months', 'Exotic Liquids'),
(3, 'A sweet syrup made from aniseed', '12 bottles of 550ml each', '12 months', 'Exotic Liquids'),
(4, 'A spicy seasoning mix for Cajun dishes', '48 jars of 6oz each', '24 months', 'New Delhi Pastry Delights'),
(5, 'A rich and flavorful gumbo mix', '36 boxes', '12 months', 'New Delhi Pastry Delights'),
(6, 'A delicious spread made from fresh boysenberries', '12 jars of 8oz each', '12 months', 'Dadi Ki Mithai'),
(7, 'Organic dried pears with a natural sweetness', '12 packs of 1lb each', '6 months', 'Dadi Ki Mithai'),
(8, 'Cranberry sauce with a tangy flavor', '12 jars of 12oz each', '6 months', 'Kolkata Craving Corner'),
(9, 'Premium kobe chicken', '18 packs of 500g each', '3 months', 'Patna Bites'),
(10, 'Rohu fish pickle', '12 jars of 200ml each', '6 months', 'Patna Bites');
SELECT * from ProductDetails

INSERT INTO ProductInventory (ProductID, Location, Quantity, LastUpdated)
VALUES 
(1, 'Warehouse A', 39, '2024-07-25'),
(2, 'Warehouse A', 17, '2024-07-25'),
(3, 'Warehouse B', 13, '2024-07-25'),
(4, 'Warehouse C', 53, '2024-07-25'),
(5, 'Warehouse C', 0, '2024-07-25'),
(6, 'Warehouse D', 120, '2024-07-25'),
(7, 'Warehouse E', 15, '2024-07-25'),
(8, 'Warehouse E', 6, '2024-07-25'),
(9, 'Warehouse F', 29, '2024-07-25'),
(10, 'Warehouse F', 31, '2024-07-25');
SELECT * from ProductInventory