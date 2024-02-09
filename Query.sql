WITH
products as 
(
	select 'product1' as Product 
	UNION 
	select 'product2'
	UNION 
	select 'product3'
),
categories as 
(
	select 'cat1' as Category 
	UNION 
	select 'cat2'
),
product_in_category as
(
	select 'product1' as Product, 'cat1' as Category
	UNION
	select 'product2', 'cat1'
	UNION
	select 'product2', 'cat2'
)
select p.Product,pc.Category 
	from products p
left join product_in_category pc 
	on p.Product = pc.Product