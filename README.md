##Question 4 queries
Assumptions made:
1. ID is the primary key in both tables
2. CUSTOMER_ID is a foreign key to Customers
3. Queries that ask for "all customers" without specifying any columns should select every column in the Customers table 
4. "Between 2 and 5" is inclusive

1.

    SELECT * FROM Customers

2.

    SELECT DISTINCT    c.*
    FROM               Customers AS c INNER JOIN
                       Orders AS o ON o.CUSTOMER_ID = c.ID

3.

    SELECT DISTINCT    c.*
    FROM               Customers AS c LEFT OUTER JOIN
                       Orders AS o ON o.CUSTOMER_ID = c.ID
    WHERE              o.ID IS NULL

4.
I would try to choose columns to index based on how commonly I would expect the column to feature in queries involving that table. Going off that criteria, and knowing nothing besides the schema for these two tables, I would expect CUSTOMER_ID to be a good candidate for the Orders table and NAME to be a good candidate for the Customers table.

5.

    SELECT     c.NAME,
               c.EMAIL,
               COUNT(o.ID) AS NumberOfOrders
    FROM       Customers AS c LEFT OUTER JOIN
               ORDERS AS o ON o.CUSTOMER_ID = c.ID
    GROUP BY   c.ID, c.NAME, c.EMAIL

6.

    SELECT     c.*	
    FROM       Customers AS c INNER JOIN
               ORDERS AS o ON o.CUSTOMER_ID = c.ID
    GROUP BY   c.ID,
               c.NAME,
               c.ADDRESS,
               c.[PHONE NUMBER],
               c.EMAIL
    HAVING     COUNT(o.ID) >= 2 AND COUNT(o.ID) <= 5