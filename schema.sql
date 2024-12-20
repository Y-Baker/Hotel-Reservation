-- Guest Table
CREATE TABLE Guest (
    SSN VARCHAR(20) PRIMARY KEY,
    F_Name VARCHAR(255) NOT NULL,
    L_Name VARCHAR(255) NOT NULL,
    Email VARCHAR(255) NOT NULL UNIQUE,
    ContactNumber VARCHAR(20),
    Address VARCHAR(255)
);

-- Room Type Table
CREATE TABLE RoomType (
    RoomTypeID INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(255) NOT NULL UNIQUE,
    Price DECIMAL(10, 2) NOT NULL,
    Description TEXT
);

-- Room Table
CREATE TABLE Room (
    RoomID INT PRIMARY KEY IDENTITY(1,1),
    RoomNumber VARCHAR(10) UNIQUE NOT NULL,
    RoomTypeID INT NOT NULL,
    Capacity INT NOT NULL,
    PricePerNight DECIMAL(10, 2) NOT NULL,
    Availability BIT DEFAULT 1,
    Location VARCHAR(255),
    Description TEXT,
    FOREIGN KEY (RoomTypeID) REFERENCES RoomType(RoomTypeID)
);

-- Amenity Table
CREATE TABLE Amenity (
    AmenityID INT PRIMARY KEY IDENTITY(1,1),
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
    BookingID INT PRIMARY KEY IDENTITY(1,1),
    GuestID VARCHAR(20) NOT NULL,
    RoomID INT NOT NULL,
    CheckIn DATE NOT NULL DEFAULT GETDATE(),
    CheckOut DATE NOT NULL,
    TotalAmount DECIMAL(10, 2) NOT NULL,
    Confirmation BIT DEFAULT 0,
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (GuestID) REFERENCES Guest(SSN),
    FOREIGN KEY (RoomID) REFERENCES Room(RoomID)
);

-- Service Table
CREATE TABLE Service (
    ServiceID INT PRIMARY KEY IDENTITY(1,1),
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
    BillingID INT PRIMARY KEY IDENTITY(1,1),
    BookingID INT NOT NULL,
    Amount DECIMAL(10, 2) NOT NULL,
    PaymentMethod VARCHAR(50) NOT NULL,
    PaymentDate DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (BookingID) REFERENCES Booking(BookingID)
);

-- Indexes
CREATE INDEX idx_guest_email ON Guest(Email);
CREATE INDEX idx_room_number ON Room(RoomNumber);
CREATE INDEX idx_booking_room ON Booking(RoomID);
CREATE INDEX idx_booking_guest ON Booking(GuestID);
