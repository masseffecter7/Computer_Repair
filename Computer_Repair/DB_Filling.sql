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
		@Discount bit,
		@Value int,
		@Name nvarchar(50),
		@Surname nvarchar(50),
		@DateOfOrder date,
		@DateOfCompletion date,
		@Guarantee nvarchar(50),
		@NameLimit INT,
		@RowCount INT,
		@NumberKinds int,
		@NumberAccessores int,
		@NumberCustomers int,
		@NumberWorkers int,
		@NumberServices int,
		@NumberOrders int,
		@AccessorieName nvarchar(50)


		SET @NumberKinds = 1000
		SET @NumberAccessores = 10000
		SET @NumberCustomers = 1000
		SET @NumberWorkers = 1000
		SET @NumberServices = 1000
		SET @NumberOrders = 10000



BEGIN TRAN

-- услуги(100)
SELECT @i=0 FROM [Services] WITH (TABLOCKX) WHERE 1=0


	SET @RowCount=1
	
	WHILE @RowCount<=@NumberServices
	BEGIN
		
		SET @Service=''
		Set @Description=''
		SET @NameLimit=5+RAND()*15 -- имя от 5 до 50 символов
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


-- виды комплектующих(100)
SELECT @i=0 FROM dbo.KindsOfAccessories WITH (TABLOCKX) WHERE 1=0
SET @RowCount=1
	
	WHILE @RowCount<=@NumberKinds
	BEGIN
		
		SET @Kind=''
		SET @Description=''
		SET @NameLimit=5+RAND()*15 -- им¤ от 5 до 20 символов
			

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



-- заказчики (100)
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

		INSERT INTO Customers (Name_Surname, Address, Telephone, Discount, Value) 
		SELECT @Name_Surname, @Addres, @Telephone, ROUND(RAND()*1,0), RAND()*500
		

		SET @RowCount +=1
	END


SELECT @i=0 FROM Accessories WITH (TABLOCKX) WHERE 1=0
SET @RowCount=1
	WHILE @RowCount<=@NumberKinds
	BEGIN

		SET @AccessorieName=''
		SET @NameLimit=5+RAND()*15 -- им¤ от 5 до 20 символов
		SET @Description=''
		SET @NameLimit=5+RAND()*15 -- им¤ от 5 до 20 символов
			
		SET @i=1

		WHILE @i<=@NameLimit
		BEGIN

			SET @Position=RAND()*11
			SET @AccessorieName = @AccessorieName + SUBSTRING(@Symbol, @Position, 1)
			SET @Position=RAND()*11
			SET @Description = @Description + SUBSTRING(@Symbol, @Position, 1)
			SET @i=@i+1
		END

		INSERT INTO Accessories (KindID, AccessorieName, [Description], Price) 
		SELECT CAST( (1+RAND()*(@NumberKinds-1)) as int), @AccessorieName, @Description, RAND()*500
		
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

	WHILE @RowCount<=@NumberWorkers
	BEGIN
	
		SET @Guarantee=''
		SET @NameLimit=0+RAND()*2 
				
		SET @i=1

		WHILE @i<=@NameLimit
		BEGIN

			SET @Position=RAND()*11
			SET @Guarantee = @Guarantee + SUBSTRING(@SymbolTelephone, @Position, 1)
			SET @i=@i+1
		END

		SET @DateOfOrder=dateadd(day,-RAND()*15000,GETDATE())
		SET @DateOfCompletion=dateadd(day,-RAND()*15000,GETDATE())
		INSERT INTO dbo.Orders (DateOfOrder, DateOfCompletion, CustomerID, ListOfAccessories, Prepaid, Submitted, Completed, TotalCost, Guarantee, ListOfServices, WorkerID) 
		SELECT @DateOfOrder, @DateOfCompletion, CAST( (1+RAND()*(@NumberCustomers-1)) as int), ROUND(RAND()*1000, 0), RAND()*300, ROUND(RAND()*1,0), ROUND(RAND()*1,0), RAND()*500, @Guarantee, ROUND(RAND()*1000, 0), CAST( (1+RAND()*(@NumberWorkers-1)) as int)
		
		SET @RowCount +=1
	END
COMMIT TRAN
GO