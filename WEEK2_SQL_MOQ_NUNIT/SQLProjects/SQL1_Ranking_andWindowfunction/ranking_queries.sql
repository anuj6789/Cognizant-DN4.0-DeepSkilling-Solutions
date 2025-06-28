
SELECT 
    category_name,
    product_name,
    price,
    row_num_rank
FROM (
    SELECT 
        c.category_name,
        p.product_name,
        p.price,
        ROW_NUMBER() OVER (
            PARTITION BY c.category_id 
            ORDER BY p.price DESC
        ) AS row_num_rank
    FROM products p
    JOIN categories c ON p.category_id = c.category_id
) AS ranked
WHERE row_num_rank <= 3;


SELECT 
    category_name,
    product_name,
    price,
    rank_num
FROM (
    SELECT 
        c.category_name,
        p.product_name,
        p.price,
        RANK() OVER (
            PARTITION BY c.category_id 
            ORDER BY p.price DESC
        ) AS rank_num
    FROM products p
    JOIN categories c ON p.category_id = c.category_id
) AS ranked
WHERE rank_num <= 3;


SELECT 
    category_name,
    product_name,
    price,
    dense_rank_num
FROM (
    SELECT 
        c.category_name,
        p.product_name,
        p.price,
        DENSE_RANK() OVER (
            PARTITION BY c.category_id 
            ORDER BY p.price DESC
        ) AS dense_rank_num
    FROM products p
    JOIN categories c ON p.category_id = c.category_id
) AS ranked
WHERE dense_rank_num <= 3;
