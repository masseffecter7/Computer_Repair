USE Computer_Repair


SET NOCOUNT ON


DECLARE @Symbol CHAR(52)= 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz',
		@SymbolTelephone CHAR(11) = '1234567890-',
		@Position INT,
		@i INT,
		@Kind nvarchar(50),
		@Service nvarchar(50),
		@Description nvarchar(50),
		@Name_Surname nvarchar(50),
		@Addres nvarchar(50),
		@Telephone nvarchar(50),
		@Value int,
		@Name nvarchar(50),
		@Surname nvarchar(50),
		@DateOfOrder date,
		@DateOfCompletion date,
		@NameLimit INT,
		@RowCount INT,
		@NumberKinds int,
		@NumberAccessories int,
		@NumberCustomers int,
		@NumberWorkers int,
		@NumberServices int,
		@NumberOrders int,
		@AccessorieName nvarchar(50),
		@Firm nvarchar(50),
		@Country nvarchar (50),
		@ReleaseDate date,
		@Characteristics nvarchar (50)


		SET @NumberKinds = 1000
		SET @NumberAccessories = 10000
		SET @NumberCustomers = 1000
		SET @NumberWorkers = 1000
		SET @NumberServices = 1000
		SET @NumberOrders = 10000



BEGIN TRAN

-- услуги(1000)
SELECT @i=0 FROM [Services] WITH (TABLOCKX) WHERE 1=0


	SET @RowCount=1
	
	WHILE @RowCount<=@NumberServices
	BEGIN
		
		SET @Service=''
		Set @Description=''
		SET @NameLimit=5+RAND()*10 -- имя от 5 до 50 символов
		SET @i=1

		WHILE @i<=@NameLimit
		BEGIN
			SET @Position=RAND()*52
			SET @Service = @Service + SUBSTRING(@Symbol, @Position, 1)
			SET @Position=RAND()*52
			SET @Description = @Description + SUBSTRING(@Symbol, @Position, 1)
			SET @i=@i+1
		END

		INSERT INTO [Services] ([Service], [Description], Price) 
		SELECT @Service, @Description, RAND()*500
		

		SET @RowCount +=1
	END


-- виды комплектующих(1000)
SELECT @i=0 FROM dbo.KindsOfAccessories WITH (TABLOCKX) WHERE 1=0
SET @RowCount=1
	
	WHILE @RowCount<=@NumberKinds
	BEGIN
		
		SET @Kind=''
		SET @Description=''
		SET @NameLimit=5+RAND()*10 -- им¤ от 5 до 20 символов
			

		SET @i=1

		WHILE @i<=@NameLimit
		BEGIN
			SET @Position=RAND()*52
			SET @Kind = @Kind + SUBSTRING(@Symbol, @Position, 1)
			SET @Position=RAND()*52
			SET @Description = @Description + SUBSTRING(@Symbol, @Position, 1)
			SET @i=@i+1
		END

		INSERT INTO KindsOfAccessories (Kind, [Description]) 
		SELECT @Kind, @Description
		

		SET @RowCount +=1
	END



-- заказчики (1000)
SELECT @i=0 FROM Customers WITH (TABLOCKX) WHERE 1=0
SET @RowCount=1
	
	WHILE @RowCount<=@NumberCustomers
	BEGIN
		
		SET @Name_Surname=''
		SET @Addres=''
		SET @Telephone=''
		SET @NameLimit=5+RAND()*10 -- им¤ от 5 до 20 символов
			

		SET @i=1

		WHILE @i<=@NameLimit
		BEGIN
			SET @Position=RAND()*52
			SET @Name_Surname = @Name_Surname + SUBSTRING(@Symbol, @Position, 1)
			SET @Position=RAND()*52
			SET @Addres = @Addres + SUBSTRING(@Symbol, @Position, 1)
			SET @Position=RAND()*11
			SET @Telephone = @Telephone + SUBSTRING(@SymbolTelephone, @Position, 1)
			SET @i=@i+1
		END

		INSERT INTO Customers (Name_Surname, [Address], Telephone, Discount, Value) 
		SELECT @Name_Surname, @Addres, @Telephone, ROUND(RAND()*1,0), RAND()*500
		

		SET @RowCount +=1
	END


SELECT @i=0 FROM Accessories WITH (TABLOCKX) WHERE 1=0
SET @RowCount=1
	WHILE @RowCount<=@NumberAccessories
	BEGIN

		SET @AccessorieName=''
		SET @NameLimit=5+RAND()*10 -- им¤ от 5 до 20 символов
		SET @Firm=''
		SET @NameLimit=5+RAND()*10 -- им¤ от 5 до 20 символов
		SET @Country=''
		SET @NameLimit=5+RAND()*10 -- им¤ от 5 до 20 символов
		SET @Characteristics=''
		SET @NameLimit=5+RAND()*10 -- им¤ от 5 до 20 символов
		SET @Description=''
		SET @NameLimit=5+RAND()*10 -- им¤ от 5 до 20 символов

		SET @i=1

		WHILE @i<=@NameLimit
		BEGIN

			SET @Position=RAND()*11
			SET @AccessorieName = @AccessorieName + SUBSTRING(@Symbol, @Position, 1)
			SET @Position=RAND()*11
			SET @Firm = @Firm + SUBSTRING(@Symbol, @Position, 1)
			SET @Position=RAND()*11
			SET @Country = @Country + SUBSTRING(@Symbol, @Position, 1)
			SET @Position=RAND()*11
			SET @Characteristics = @Characteristics + SUBSTRING(@Symbol, @Position, 1)
			SET @Position=RAND()*11
			SET @Description = @Description + SUBSTRING(@Symbol, @Position, 1)
						
			SET @i=@i+1
		END

		SET @ReleaseDate=dateadd(day,-RAND()*15000,GETDATE())
		INSERT INTO Accessories (KindID, AccessorieName, Firm, Country, ReleaseDate, Characteristics, Guarantee, [Description], Price) 
		SELECT CAST( (1+RAND()*(@NumberKinds-1)) as int), @AccessorieName, @Firm, @Country, @ReleaseDate, @Characteristics, ROUND(RAND()*10,0), @Description, RAND()*500
		
		SET @RowCount +=1
	END


SELECT @i=0 FROM Workers WITH (TABLOCKX) WHERE 1=0
SET @RowCount=1
	WHILE @RowCount<=@NumberWorkers
	BEGIN

		SET @Name=''
		SET @Surname=''
		SET @NameLimit=5+RAND()*10 -- им¤ от 5 до 20 символов
			
		SET @i=1

		WHILE @i<=@NameLimit
		BEGIN

			SET @Position=RAND()*15
			SET @Name = @Name + SUBSTRING(@Symbol, @Position, 1)
			SET @Position=RAND()*15
			SET @Surname = @Surname + SUBSTRING(@Symbol, @Position, 1)
			SET @i=@i+1
		END

		INSERT INTO dbo.Workers (Name, Surname) 
		SELECT @Name, @Surname
		
		SET @RowCount +=1
	END



	SELECT @i=0 FROM Orders WITH (TABLOCKX) WHERE 1=0
	
	SET @RowCount=1

	WHILE @RowCount<=@NumberOrders
	BEGIN
	
		SET @NameLimit=0+RAND()*2 
				
		SET @i=1

		WHILE @i<=@NameLimit
		BEGIN

			SET @Position=RAND()*11
			SET @i=@i+1
		END

		SET @DateOfOrder=dateadd(day,-RAND()*15000,GETDATE())
		SET @DateOfCompletion=dateadd(day,-RAND()*15000,GETDATE())
		INSERT INTO dbo.Orders (DateOfOrder, DateOfCompletion, CustomerID, AccessorieId, Prepaid, Submitted, Completed, TotalCost, Guarantee, ServiceId, WorkerID) 
		SELECT @DateOfOrder, @DateOfCompletion, CAST( (1+RAND()*(@NumberCustomers-1)) as int), CAST( (1+RAND()*(@NumberAccessories-1)) as int), ROUND(RAND()*1,0), ROUND(RAND()*1,0), ROUND(RAND()*1,0), RAND()*500, ROUND(RAND()*10,0), CAST( (1+RAND()*(@NumberServices-1)) as int), CAST( (1+RAND()*(@NumberWorkers-1)) as int)
		
		SET @RowCount +=1
	END
COMMIT TRAN
GO