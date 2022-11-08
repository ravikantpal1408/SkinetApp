import axios from 'axios';
import React, { useEffect, useState } from 'react';
import ProductList from './Components/Products/Product.component';
import Header from './Layout/Header/Header';
import { Products } from './Models/Products';


function App () {
  const [data, setData] = useState<Products[]>([]);

  useEffect(()=>{
    axios.get('https://localhost:44396/api/Product/products').then(res => {
      setData(res.data);
      
    }).catch(er => console.error(er));
  },[])

  return(
    <>
      <Header/>
      <ProductList  products={data}/>
           
     
    </>
  )
}


export default App;
