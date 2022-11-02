import React from 'react';
interface AppProps
{
    
}

interface AppState
{
    data : any,
}
class App extends React.Component<AppProps,AppState> {
    
    constructor(props: any) {
        super(props);
        this.state = {
            data: [
                { Id: 1 , name: 'ravikantpal'},
                { Id: 2 , name: 'johnwick'}
            ]
        }
    }
    
    
    componentDidMount(){
        
        console.log(this.state.data)
        fetch(`https://localhost:44396/api/Product/products`)
            .then(res => {console.log(res)});
    }
    
    render(){
        return (
            <div className="App">
                <h1>Hello there 😎</h1>
            </div>
        );
    }
  
}

export default App;
