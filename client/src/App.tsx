import React from 'react';


interface AppState
{
    data : any,
}
class App extends React.Component<AppState> {
    
    constructor(props: any) {
        super(props);
        this.state = {
            data: []
        }
    }
    
    
    componentDidMount(){
        console.log('😀')
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
