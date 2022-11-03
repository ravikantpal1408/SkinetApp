import axios from 'axios';
import React from 'react';
interface AppProps {
  
}

interface AppState {
  data: []
}
class App extends React.Component<AppProps, AppState> {

  constructor(props: any) {
    super(props);
  

  }

  componentDidMount(): void {
    axios.get('https://localhost:5001/api/Product/products').then(res => {
      this.setState({
        data: res.data
      });
    });
  }

  render() {

    const products = this.state?.data || []
    
    return (
      <>
      
        <h1>Hello there skinet 😊😊</h1>
        {this.state?.data != null ? (<h2>data is present</h2>) : ''} 
        {products.map( (e,i)=> 
          <h3 key={i}>Product Description : {i} </h3>
        )}
      </>
    );
  }

}

export default App;
