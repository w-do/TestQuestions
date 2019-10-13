A take-home coding test for an interview I had in September 2018.

## Question 1
> Write a C# application that solves the following problem:
>
> Take in 3 integer inputs, representing the sides of a triangle, and return the triangle type (Scalene, isosceles, equilateral).
>
> Support this answer with unit tests.

See Triangle and Triangle.Test for solution and tests.

My assumptions:
- Any positive int32 (1 to 2,147,483,647) will be accepted for a triangle side.
- Entering a side with a value less than one will return the output "Not a valid triangle".
- Entering three sides that cannot form a valid triangle in euclidean space will return the output "Not a valid triangle".

## Question 2
> Write a C# application that solves the following problem:
>
> Return the 5th element **from the end** of a singly linked list of integers.  Do not iterate the list more than once.  Assume the list size cannot be known without traversing the list.
>
> Support this answer with unit tests.
>
> Solve the same question but assume the linked list contains strings instead of integers.

See LinkedList and LinkedList.Test for solution and tests

My assumptions:
- No information was provided re: user input, unlike questions 1 and 3, so the integer linked list is a list of the integers from 1 to 100 while the string linked list is a list of dates, one year apart, from 1901-01-01 to 2000-01-01.

## Question 3
> Write a C# application that solves the following problem:
>
> Take as input the path to a file containing one integer per line. For each integer in the file, output to the console a comma-delimited list of the integer's prime factors. The list of integers on each line of the output should multiply to produce the input integer. 
>
> Support your work with a rich set of unit tests.

See PrimeFactors and PrimeFactors.Test for solution and tests.

My assumptions:
- Values in the file to be prime factored must be within the range of int32 (-2,147,483,648 to 2,147,483,647).
- The output for any integers less than 2 in the specified file will be a blank line, as all integers below 2 are neither composite nor prime.

## Question 4 queries

> Assume a database with the following structure
>
> Customers
>
> | ID | NAME | ADDRESS | PHONE NUMBER | EMAIL |
> | --- | --- | --- | --- | --- |
>
> Orders
>
> | ID | CUSTOMER_ID | ORDER_AMOUNT | ORDER_ADDRESS |
> | --- | --- | --- | --- |

My assumptions:
- ID is the primary key in both tables
- CUSTOMER_ID is a foreign key to Customers
- Queries that ask for "all customers" without specifying any columns should select every column in the Customers table 
- "Between 2 and 5" is inclusive

1. Write a SQL Query to pull all customers

        SELECT * FROM Customers

2. Write a SQL Query to pull all customers that have orders (no duplicates)

        SELECT DISTINCT     c.*
        FROM                Customers AS c INNER JOIN
                            Orders AS o ON o.CUSTOMER_ID = c.ID

3. Write a SQL Query to pull all customers that do not have orders

        SELECT DISTINCT     c.*
        FROM                Customers AS c LEFT OUTER JOIN
                            Orders AS o ON o.CUSTOMER_ID = c.ID
        WHERE               o.ID IS NULL

4. If you had to create an index on these tables, which fields would you most likely index and why?


    I would try to choose columns to index based on how commonly I would expect the column to feature in queries involving that table. Going off that criteria, and knowing nothing besides the schema for these two tables, I would expect CUSTOMER_ID to be a good candidate for the Orders table and NAME to be a good candidate for the Customers table.

5. Write a query that lists each customer name, email, and the number of order they have 

        SELECT      c.NAME,
                    c.EMAIL,
                    COUNT(o.ID) AS NumberOfOrders
        FROM        Customers AS c LEFT OUTER JOIN
                    ORDERS AS o ON o.CUSTOMER_ID = c.ID
        GROUP BY    c.ID, c.NAME, c.EMAIL

6. Write a query that pulls all customers that have between 2 and 5 orders

        SELECT      c.*	
        FROM        Customers AS c INNER JOIN
                    ORDERS AS o ON o.CUSTOMER_ID = c.ID
        GROUP BY    c.ID,
                    c.NAME,
                    c.ADDRESS,
                    c.[PHONE NUMBER],
                    c.EMAIL
        HAVING      COUNT(o.ID) >= 2 AND COUNT(o.ID) <= 5
