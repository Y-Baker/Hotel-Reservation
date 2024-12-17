-- Guest Table
CREATE TABLE Guest (
    GuestID INT PRIMARY KEY AUTO_INCREMENT,
    SSN VARCHAR(20) UNIQUE,
    F_Name VARCHAR(50) NOT NULL,
    L_Name VARCHAR(50) NOT NULL,
    Email VARCHAR(100),
    ContactNumber VARCHAR(20),
    Address VARCHAR(255)
);

-- Room Type Table
CREATE TABLE RoomType (
    RoomTypeID INT PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(50) NOT NULL UNIQUE,
    Price DECIMAL(10, 2) NOT NULL,
    Description TEXT
);


-- Room Table
CREATE TABLE Room (
    RoomID INT PRIMARY KEY AUTO_INCREMENT,
    RoomNumber VARCHAR(10) UNIQUE NOT NULL,
    RoomTypeID INT NOT NULL,
    Capacity INT NOT NULL,
    PricePerNight DECIMAL(10, 2) NOT NULL,
    StatusID INT NOT NULL,
    Location VARCHAR(255),
    Description TEXT,
    FOREIGN KEY (RoomTypeID) REFERENCES RoomType(RoomTypeID),
    FOREIGN KEY (StatusID) REFERENCES RoomStatus(StatusID)
);


-- Amenity Table
CREATE TABLE Amenity (
    AmenityID INT PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(50) NOT NULL UNIQUE,
    Description TEXT
);


-- Room Amenity Table
CREATE TABLE RoomAmenity (
    RoomID INT NOT NULL,
    AmenityID INT NOT NULL,
    Quantity INT DEFAULT 1,
    PRIMARY KEY (RoomID, AmenityID),
    FOREIGN KEY (RoomID) REFERENCES Room(RoomID),
    FOREIGN KEY (AmenityID) REFERENCES Amenity(AmenityID)
);


-- Booking Table
CREATE TABLE Booking (
    BookingID INT PRIMARY KEY AUTO_INCREMENT,
    GuestID INT NOT NULL,
    RoomID INT NOT NULL,
    CheckIn DATE NOT NULL,
    CheckOut DATE NOT NULL,
    TotalAmount DECIMAL(10, 2) NOT NULL,
    Confirmation VARCHAR(50) UNIQUE,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (GuestID) REFERENCES Guest(GuestID),
    FOREIGN KEY (RoomID) REFERENCES Room(RoomID)
);


-- Service Table
CREATE TABLE Service (
    ServiceID INT PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(50) NOT NULL UNIQUE,
    Description TEXT,
    Price DECIMAL(10, 2) NOT NULL
);


-- Booking Service Table
CREATE TABLE BookingService (
    BookingID INT NOT NULL,
    ServiceID INT NOT NULL,
    Quantity INT NOT NULL DEFAULT 1,
    PRIMARY KEY (BookingID, ServiceID),
    FOREIGN KEY (BookingID) REFERENCES Booking(BookingID),
    FOREIGN KEY (ServiceID) REFERENCES Service(ServiceID)
);


-- Billing Table
CREATE TABLE Billing (
    BillingID INT PRIMARY KEY AUTO_INCREMENT,
    BookingID INT NOT NULL,
    Amount DECIMAL(10, 2) NOT NULL,
    PaymentMethod VARCHAR(50) NOT NULL,
    PaymentDate TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (BookingID) REFERENCES Booking(BookingID)
);



-- Additional Indexes
-- CREATE INDEX idx_role_name ON Role(role_name);
-- CREATE INDEX idx_status_name ON Status(status_name);
-- CREATE INDEX idx_location_country ON Location(country);
-- CREATE INDEX idx_user_email ON User(email);
-- CREATE INDEX idx_property_location ON Property(location_id);
-- CREATE INDEX idx_booking_property ON Booking(property_id);
-- CREATE INDEX idx_payment_booking ON Payment(booking_id);
