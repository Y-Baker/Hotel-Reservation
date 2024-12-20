-- Insert into Guest Table
INSERT INTO Guest (SSN, F_Name, L_Name, Email, ContactNumber, Address)
VALUES 
('1234567890', 'Yousef', 'Ali', 'yousef.ali@example.com', '1234567890', '123 Elm Street'),
('2345678901', 'Mohamed', 'Hassan', 'mohamed.hassan@example.com', '0987654321', '456 Maple Avenue'),
('3456789012', 'Ahmed', 'Saeed', 'ahmed.saeed@example.com', '1122334455', '789 Oak Drive'),
('4567890123', 'Fatima', 'Mahmoud', 'fatima.mahmoud@example.com', '1231231234', '321 Birch Lane'),
('5678901234', 'Hala', 'Ibrahim', 'hala.ibrahim@example.com', '9876543210', '654 Pine Circle'),
('6789012345', 'Omar', 'Kamal', 'omar.kamal@example.com', '5647382910', '987 Spruce Way'),
('7890123456', 'Amal', 'Nabil', 'amal.nabil@example.com', '4321567890', '654 Cedar Road'),
('8901234567', 'Nada', 'Mostafa', 'nada.mostafa@example.com', '3124567890', '159 Walnut Street'),
('9012345678', 'Hussein', 'Zaki', 'hussein.zaki@example.com', '6453728190', '753 Cherry Drive'),
('0123456789', 'Laila', 'Ahmed', 'laila.ahmed@example.com', '9876123450', '258 Ash Avenue');

-- Insert into RoomType Table
INSERT INTO RoomType (Name, Price, Description)
VALUES 
('Single', 100.00, 'A single bed room'),
('Double', 150.00, 'A room with two beds'),
('Suite', 250.00, 'A luxurious suite with additional amenities');

-- Insert into Room Table
INSERT INTO Room (RoomNumber, RoomTypeID, Capacity, PricePerNight, Availability, Location, Description)
VALUES 
('101', 1, 1, 100.00, 1, 'First Floor', 'Cozy single room'),
('102', 1, 1, 100.00, 1, 'First Floor', 'Single room with garden view'),
('201', 2, 2, 150.00, 1, 'Second Floor', 'Double room with balcony'),
('202', 2, 2, 150.00, 1, 'Second Floor', 'Double room with street view'),
('301', 3, 4, 250.00, 1, 'Third Floor', 'Luxury suite with a city view'),
('302', 3, 4, 250.00, 1, 'Third Floor', 'Suite with extra amenities'),
('401', 1, 1, 100.00, 1, 'Ground Floor', 'Economy single room'),
('402', 2, 2, 150.00, 1, 'Ground Floor', 'Double room for budget travelers'),
('501', 3, 4, 250.00, 1, 'Fourth Floor', 'Presidential suite with premium facilities'),
('601', 3, 4, 250.00, 1, 'Fifth Floor', 'Suite with exclusive design');

-- Insert into Amenity Table
INSERT INTO Amenity (Name, Description)
VALUES 
('WiFi', 'Free wireless internet'),
('TV', 'Flat-screen television'),
('Mini Bar', 'Small refrigerator with drinks and snacks'),
('Air Conditioning', 'Cooling and heating system'),
('Safe', 'Secure safe for valuables'),
('Coffee Maker', 'In-room coffee machine'),
('Bathrobe', 'Soft bathrobe and slippers'),
('Work Desk', 'Spacious desk for work'),
('Iron', 'Iron and ironing board'),
('Hair Dryer', 'High-quality hair dryer');

-- Insert into RoomAmenity Table
INSERT INTO RoomAmenity (RoomID, AmenityID, Quantity)
VALUES 
(1, 1, 1), (1, 2, 1), (2, 1, 1), (2, 2, 1), (2, 3, 1),
(3, 1, 1), (3, 2, 1), (3, 3, 1), (3, 4, 1), (3, 5, 1),
(4, 6, 1), (4, 7, 1), (5, 1, 1), (5, 8, 1), (6, 9, 1),
(7, 1, 1), (8, 10, 1), (9, 1, 1), (10, 5, 1), (10, 6, 1);

-- Insert into Booking Table
INSERT INTO Booking (GuestID, RoomID, CheckIn, CheckOut, TotalAmount, Confirmation)
VALUES 
('1234567890', 1, '2024-12-21', '2024-12-25', 400.00, 1),
('2345678901', 2, '2024-12-22', '2024-12-27', 750.00, 1),
('3456789012', 3, '2024-12-23', '2024-12-28', 1250.00, 0),
('4567890123', 4, '2024-12-24', '2024-12-29', 1500.00, 1),
('5678901234', 5, '2024-12-25', '2024-12-30', 1000.00, 1),
('6789012345', 6, '2024-12-26', '2024-12-31', 2500.00, 1),
('7890123456', 7, '2024-12-27', '2025-01-01', 400.00, 0),
('8901234567', 8, '2024-12-28', '2025-01-02', 480.00, 1),
('9012345678', 9, '2024-12-29', '2025-01-03', 1200.00, 1),
('0123456789', 10, '2024-12-30', '2025-01-04', 5000.00, 1);

-- Insert into Service Table
INSERT INTO Service (Name, Description, Price)
VALUES 
('Room Cleaning', 'Daily room cleaning service', 20.00),
('Laundry', 'Laundry service', 15.00),
('Breakfast', 'Daily breakfast service', 10.00),
('Airport Transfer', 'Pick-up and drop-off to the airport', 50.00),
('Gym Access', 'Access to the gym facilities', 30.00),
('Spa', 'Relaxing spa treatments', 100.00),
('Mini Bar Refill', 'Restock of the mini bar', 25.00),
('Extra Towels', 'Additional towels for use', 5.00),
('Pet Care', 'Pet-friendly services', 40.00),
('Dinner', 'Dinner service in the room', 60.00);

-- Insert into BookingService Table
INSERT INTO BookingService (BookingID, ServiceID, Quantity)
VALUES 
(1, 1, 4), (1, 3, 4), (2, 2, 5), (2, 3, 5), (3, 4, 1),
(4, 5, 1), (5, 6, 2), (6, 7, 1), (7, 8, 3), (8, 9, 1);

-- Insert into Billing Table
INSERT INTO Billing (BookingID, Amount, PaymentMethod, PaymentDate)
VALUES 
(1, 400.00, 'Credit Card', GETDATE()),
(2, 750.00, 'Cash', GETDATE()),
(3, 1250.00, 'Credit Card', GETDATE()),
(4, 1500.00, 'Debit Card', GETDATE()),
(5, 1000.00, 'Cash', GETDATE()),
(6, 2500.00, 'Credit Card', GETDATE()),
(7, 400.00, 'Credit Card', GETDATE()),
(8, 480.00, 'Debit Card', GETDATE()),
(9, 1200.00, 'PayPal', GETDATE()),
(10, 5000.00, 'Credit Card', GETDATE());