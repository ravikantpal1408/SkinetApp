
import { useState, useEffect } from "react";
import { Products } from "../../Models/Products";
import ProductList from "./ProductList.component";
import axios from 'axios';

 

 export default function Catalog() {
     const [products, setProducts] = useState<Products[]>([]);

     useEffect(() => {
        axios.get('https://localhost:44396/api/Product/products').then(res => {
            setProducts(res.data);    
        }).catch(er => console.error(er));
      }, [])

     return (
         <>
             <ProductList products={products} />
         </>
     )
 }