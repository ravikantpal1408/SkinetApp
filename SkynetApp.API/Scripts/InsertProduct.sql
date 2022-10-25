  USE [skinetDB];
  GO
  INSERT INTO [skinetDB].[dbo].[tblProduct] ([Name], [Description], [Price], [PictureUrl], [Type], [Brand], [QuantityInStock])
  VALUES('Product 1', 'Description about product one', 10.20, '/somedir/some1.jpg', 'Type 1' , 'Brand 1', 10),
  ('Product 2', 'Description about product two', 20.21, '/somedir/some2.jpg', 'Type 2' , 'Brand 2', 200),
  ('Product 3', 'Description about product three', 40.99, '/somedir/some3.jpg', 'Type 3' , 'Brand 3', 100),
  ('Product 4', 'Description about product four', 6.97, '/somedir/some4.jpg', 'Type 4' , 'Brand 4', 33),
  ('Product 5', 'Description about product five', 2.99, '/somedir/some5.jpg', 'Type 5' , 'Brand 5', 939);