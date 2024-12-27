CREATE SCHEMA IF NOT EXISTS `cooking` DEFAULT CHARACTER SET utf8mb3;
USE `cooking`;

CREATE TABLE IF NOT EXISTS Dish (
    DishID INT PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(255) NOT NULL,
    Category VARCHAR(50) NOT NULL,
    Recipe TEXT NOT NULL,
    PortionWeight DECIMAL(5, 2) NOT NULL
);

CREATE TABLE IF NOT EXISTS ProductCategory (
    CategoryID INT PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(50)
);

CREATE TABLE IF NOT EXISTS Product (
    ProductID INT PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(255) NOT NULL,
    CategoryID INT NOT NULL,
    Calories DECIMAL(6, 2) NOT NULL,
    PricePerUnit DECIMAL(10, 2) NOT NULL,
    UnitOfMeasure VARCHAR(20) NOT NULL,
    FOREIGN KEY (CategoryID) REFERENCES ProductCategory(CategoryID)
);

CREATE TABLE IF NOT EXISTS DishComposition (
    DishID INT NOT NULL,
    ProductID INT NOT NULL,
    PreparationMethod VARCHAR(50),
    Quantity DECIMAL(10, 2) NOT NULL,
    OrderOfAdding INT NOT NULL,
    PortionCount INT NOT NULL,
    PRIMARY KEY (DishID, ProductID),   
    FOREIGN KEY (DishID) REFERENCES Dish(DishID) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (ProductID) REFERENCES Product(ProductID)
);

INSERT INTO Dish (Name, Category, Recipe, PortionWeight)
VALUES 
('Борщ', 'первое', 'Варить 1 час, добавить сметану перед подачей', 300),
('Щи', 'первое', 'Варить 2 часа, добавить зелень и сметану перед подачей', 350),
('Оливье', 'Салат', 'Смешать все ингредиенты, варить', 250),
('Шарлотка', 'Десерт', 'Запекать в духовке 40 минут', 150),
('Пельмени', 'первое', 'Варить 20 минут в подсоленной воде', 200),
('Ризотто', 'первое', 'Жарить 20 минут, добавить бульон и довести до готовности', 250),
('Салат "Цезарь"', 'Салат', 'Смешать все ингредиенты, добавить соус', 200),
('Торт "Наполеон"', 'Десерт', 'Запекать коржи и собирать торт', 300),
('Гречневая каша', 'первое', 'Варить 15 минут, добавить масло', 250),
('Котлеты', 'второе', 'Жарить на сковороде до золотистой корочки', 200),
('Пирог с яблоками', 'Десерт', 'Запекать 40 минут, охладить перед подачей', 180),
('Картофельное пюре', 'гарнир', 'Варить, затем разомнуть с маслом и молоком', 150),
('Запечённая рыба', 'второе', 'Запекать с лимоном и зеленью в духовке', 250),
('Паста с соусом', 'первое', 'Отварить пасту, приготовить соус и смешать', 200);

INSERT INTO ProductCategory (Name) VALUES 
('Овощи'), 
('Мясо'), 
('Мучное изделие'), 
('Молочные продукты'),
('Пряность'),
('Зелень'),
('Фрукты'),
('Морепродукты'),
('Консервация'),
('Напитки'),
('Бобовые'),
('Крупы'),
('Сладости'),
('Замороженные продукты');

INSERT INTO Product (Name, CategoryID, Calories, PricePerUnit, UnitOfMeasure) VALUES
('Свекла', 1, 43, 40, 'кг'),
('Лук', 1, 28, 10, 'кг'),
('Картофель', 1, 77, 30, 'кг'),
('Курица', 2, 239, 200, 'кг'),
('Мука', 3, 364, 50, 'кг'),
('Яйца', 4, 155, 80, 'шт'),
('Хлеб', 3, 387, 60, 'кг'),
('Перец молотый', 5, 5, 10, 'кг'),
('Томаты', 1, 18, 60, 'кг'),
('Гречка', 12, 343, 40, 'кг'),
('Чеснок', 1, 149, 120, 'кг'),
('Сметана', 4, 199, 90, 'шт'),
('Укроп', 6, 43, 50, 'кг'),
('Яблоки', 7, 52, 80, 'кг'),
('Креветки', 8, 99, 300, 'кг'),
('Огурцы', 1, 16, 30, 'кг'),
('Морковь', 1, 41, 35, 'кг'),
('Тунец консервированный', 9, 130, 150, 'банка'),
('Лимонад', 10, 45, 50, 'л'),
('Фасоль', 11, 127, 60, 'кг'),
('Рис', 12, 365, 45, 'кг'),
('Шоколад', 13, 530, 200, 'плитка'),
('Смородина замороженная', 14, 50, 150, 'кг'),
('Капуста', 1, 25, 30, 'кг'),
('Творог', 4, 136, 100, 'кг'),
('Масло сливочное', 4, 717, 250, 'кг'),
('Сахар', 13, 400, 40, 'кг');

INSERT INTO DishComposition (DishID, ProductID, PreparationMethod, Quantity, OrderOfAdding, PortionCount)
VALUES 
(1, 1, 'варка', 0.3, 2, 4),  -- Борщ, Свекла, 300 г на 4 порции
(1, 2, 'пассеровка', 0.5, 1, 4),  -- Борщ, Лук, 500 г на 4 порции
(1, 3, 'жарка', 0.4, 3, 4),  -- Борщ, Курица, 400 г на 4 порции
(1, 8, 'добавить', 0.01, 4, 4),  -- Борщ, Сметана, 10 мл на 4 порции
(2, 2, 'тушение', 0.2, 1, 4),  -- Щи, Картофель, 200 г на 4 порции
(2, 5, 'копчение', 0.1, 2, 4),  -- Щи, Яйца, 100 г на 4 порции
(2, 6, 'пассеровка', 0.2, 3, 4),  -- Щи, Укроп, 200 г на 4 порции
(2, 1, 'варка', 0.2, 4, 4),  -- Щи, Свекла, 200 г на 4 порции
(5, 3, 'жарка', 0.3, 1, 4),  -- Ризотто, Мука, 300 г на 4 порции
(5, 12, 'варка', 0.2, 2, 4),  -- Ризотто, Гречка, 200 г на 4 порции
(6, 4, 'копчение', 0.3, 1, 6),  -- Цезарь, Курица, 300 г на 6 порций
(6, 9, 'запекание', 0.1, 2, 6),  -- Цезарь, Хлеб, 100 г на 6 порций
(7, 3, 'выпечка', 0.5, 1, 4),  -- Наполеон, Мука, 500 г на 4 порции
(7, 4, 'выпечка', 0.3, 2, 4),  -- Наполеон, Яйца, 300 г на 4 порции
(7, 11, 'варка', 0.2, 3, 4),  -- Наполеон, Масло, 200 г на 4 порции
(7, 13, 'выпечка', 0.1, 4, 4),  -- Наполеон, Сахар, 100 г на 4 порции
(8, 1, 'варка', 0.25, 1, 5),  -- Гречневая каша, Свекла, 250 г на 5 порций
(8, 7, 'жарка', 0.2, 2, 5),  -- Гречневая каша, Яблоки, 200 г на 5 порций
(9, 7, 'жарка', 0.2, 1, 4),  -- Котлеты, Яблоки, 200 г на 4 порции
(9, 12, 'жарка', 0.5, 2, 4),  -- Котлеты, Гречка, 500 г на 4 порции
(10, 1, 'варка', 0.2, 1, 3),  -- Пирог с яблоками, Свекла, 200 г на 3 порции
(10, 7, 'жарка', 0.5, 2, 3),  -- Пирог с яблоками, Яблоки, 500 г на 3 порции
(11, 1, 'варка', 0.3, 1, 4),  -- Картофельное пюре, Картофель, 300 г на 4 порции
(11, 4, 'перемешивание', 0.1, 2, 4),  -- Картофельное пюре, Масло, 100 г на 4 порции
(12, 8, 'запекание', 0.5, 1, 5),  -- Запечённая рыба, Креветки, 500 г на 5 порций
(12, 6, 'запекание', 0.2, 2, 5);  -- Запечённая рыба, Укроп, 200 г на 5 порций

-- выборка 1
select d.Name from Dish as d
join DishComposition as dc ON dc.DishID = d.DishID
WHERE dc.PreparationMethod = 'пассеровка';

-- выборка 2
SELECT d.Name AS DishName,
       SUM(dc.Quantity * p.Calories) / d.PortionWeight AS CaloriesPerPortion
FROM Dish AS d
JOIN DishComposition AS dc ON dc.DishID = d.DishID
JOIN Product AS p ON p.ProductID = dc.ProductID
GROUP BY d.DishID;

-- выборка 3
SELECT d.Name 
FROM Dish AS d
JOIN DishComposition AS dc ON dc.DishID = d.DishID
JOIN Product AS p ON p.ProductID = dc.ProductID
JOIN ProductCategory AS pc ON pc.CategoryID = p.CategoryID
WHERE pc.name = 'Пряность'
GROUP BY d.DishID
ORDER BY COUNT(dc.ProductID) DESC
LIMIT 1;

-- выборка 4
SELECT d.Name AS DishName, p.Name AS ProductName
FROM Dish AS d
JOIN DishComposition AS dc ON d.DishID = dc.DishID
JOIN Product AS p ON dc.ProductID = p.ProductID
WHERE d.Category = 'первое'
ORDER BY d.Name, dc.OrderOfAdding;





