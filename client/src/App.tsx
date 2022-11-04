import axios from 'axios';
import React, { useEffect, useState } from 'react';


function App () {
  const [data, setData] = useState<any[]>([]);

  useEffect(()=>{
    axios.get('https://localhost:44396/api/Product/products').then(res => {
      setData(res.data);
    }).catch(er => console.error(er));
  },[])

  return(
    <>
      <div>Skinet App</div>
      <ul>
          {
              data.map((el, i)=> 
                  (<li key={i}>{el.name}</li>)
              )
          }
      </ul>
    </>
  )
}


// interface AppProps {

// }

// interface AppState {
//   data: []
// }
// class App extends React.Component<AppProps, AppState> {

//   // constructor(props: any) {
//   //   super(props);
//   // }

//   componentDidMount(): void {
//     /* reduce , find  */
//     // fetch('https://localhost:44396/api/Product/products').then(res =>
//     //  res.json()
//     // )
//     // .then(da => {
//     //   this.setState({
//     //     data: da
//     //   });
//     // })
//     //.catch(er => console.error(er));
//     axios.get('https://localhost:44396/api/Product/products').then(res => {
//       this.setState({
//         data: res.data
//       });
//     }).catch(er => console.error(er));
//   }

//   render() {

//     const products: any[] = this.state?.data || []

//     let someVariable = products.filter(ele => {
//       return ele.price > 10 ? ele.name : '';
//     })

//     return (
//       <>

//         <h1>Hello there skinet 😊😊</h1>
//         {
//           someVariable.map((e, i) => {
//             return (<h2 key={i}>{e.name}</h2>)
//           })
//         }
//       </>
//     );
//   }

// }

export default App;
