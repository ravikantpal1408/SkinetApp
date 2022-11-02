import React from 'react';
import logo from './logo.svg';

class App extends React.Component {


  componentDidMount(): void {
    fetch(`https://localhost:44396/api/Product/products`)
      .then(res => {console.log(res)})
  }

  render() {
    return (
      <div className="App">
          <h1>Hello there skinet 😊😊</h1>
      </div>
    );
  }
 
}

export default App;
