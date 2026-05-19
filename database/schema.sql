CREATE TABLE Adjusters (
    AdjusterId INT PRIMARY KEY,
    Name VARCHAR(100),
    Jurisdiction VARCHAR(50),
    SkillLevel INT,
    MaxWorkload INT
);

CREATE TABLE Claims (
    ClaimId INT PRIMARY KEY,
    ClaimType VARCHAR(50),
    Jurisdiction VARCHAR(50),
    Complexity INT,
    ReceivedDate DATE
);

CREATE TABLE Assignments (
    AssignmentId INT PRIMARY KEY AUTO_INCREMENT,
    ClaimId INT NOT NULL,
    AdjusterId INT NOT NULL,
    Score DECIMAL(10, 2),
    AssignedDate DATETIME,
    FOREIGN KEY (ClaimId) REFERENCES Claims(ClaimId),
    FOREIGN KEY (AdjusterId) REFERENCES Adjusters(AdjusterId)
);

CREATE TABLE PerformanceHistory (
    RecordId INT PRIMARY KEY AUTO_INCREMENT,
    AdjusterId INT,
    CompletedClaims INT,
    AvgResolutionTime INT,
    FOREIGN KEY (AdjusterId) REFERENCES Adjusters(AdjusterId)
);
