A take-home coding test for an interview I had in September 2018.

## Question 1

- Any positive int32 (1 to 2,147,483,647) will be accepted for a triangle side.
- Entering a side with a value less than one will return the output "Not a valid triangle".
- Entering three sides that cannot form a valid triangle in euclidean space will return the output "Not a valid triangle".

## Question 2

- No information was provided re: user input, unlike questions 1 and 3, so the integer linked list is a list of the integers from 1 to 100 while the string linked list is a list of dates, one year apart, from 1901-01-01 to 2000-01-01.

## Question 3

- Values in the file to be prime factored must be within the range of int32 (-2,147,483,648 to 2,147,483,647).
- The output for any integers less than 2 in the specified file will be a blank line, as all integers below 2 are neither composite nor prime.

## Question 4 queries

Assumptions made:

- ID is the primary key in both tables
- CUSTOMER_ID is a foreign key to Customers
- Queries that ask for "all customers" without specifying any columns should select every column in the Customers table 
- "Between 2 and 5" is inclusive

1.

    SELECT * FROM Customers

2.

    SELECT DISTINCT     c.*
    FROM                Customers AS c INNER JOIN
                        Orders AS o ON o.CUSTOMER_ID = c.ID

3.

    SELECT DISTINCT     c.*
    FROM                Customers AS c LEFT OUTER JOIN
                        Orders AS o ON o.CUSTOMER_ID = c.ID
    WHERE               o.ID IS NULL

4.
I would try to choose columns to index based on how commonly I would expect the column to feature in queries involving that table. Going off that criteria, and knowing nothing besides the schema for these two tables, I would expect CUSTOMER_ID to be a good candidate for the Orders table and NAME to be a good candidate for the Customers table.

5.

    SELECT      c.NAME,
                c.EMAIL,
                COUNT(o.ID) AS NumberOfOrders
    FROM        Customers AS c LEFT OUTER JOIN
                ORDERS AS o ON o.CUSTOMER_ID = c.ID
    GROUP BY    c.ID, c.NAME, c.EMAIL

6.

    SELECT      c.*	
    FROM        Customers AS c INNER JOIN
                ORDERS AS o ON o.CUSTOMER_ID = c.ID
    GROUP BY    c.ID,
                c.NAME,
                c.ADDRESS,
                c.[PHONE NUMBER],
                c.EMAIL
    HAVING      COUNT(o.ID) >= 2 AND COUNT(o.ID) <= 5
