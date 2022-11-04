import { useState, useEffect } from "react";
import { Product } from "../../Models/Product";
import ProductList from "./ProductList";

 

 export default function Catalog() {
     const [products, setProducts] = useState<Product[]>([]);

     useEffect(() => {
         fetch('https://localhost:5001/api/Product/products')
             .then(response => response.json())
             .then(data => setProducts(data))
     }, [])

     return (
         <>
             <ProductList products={products} />
         </>
     )
 }
