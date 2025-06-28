
INSERT INTO categories (category_id, category_name) VALUES
(1, 'Electronics'),
(2, 'Clothing'),
(3, 'Home');


INSERT INTO products (product_id, product_name, category_id, price) VALUES
(101, 'Laptop', 1, 1299.99),
(102, 'Smartphone', 1, 999.99),
(103, 'Tablet', 1, 999.99), 
(104, 'Headphones', 1, 199.99),
(201, 'Jacket', 2, 299.99),
(202, 'Jeans', 2, 89.99),
(203, 'Sweater', 2, 299.99),  
(301, 'Sofa', 3, 799.99),
(302, 'Lamp', 3, 129.99);


INSERT INTO sales (sale_id, product_id, sale_date, quantity) VALUES
(1, 101, '2025-06-01', 2),
(2, 102, '2025-06-01', 5),
(3, 103, '2025-06-02', 3);
