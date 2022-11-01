import React from 'react';

class App extends React.Component {
    // constructor(props) {
    //     super();
    // }
    render()
    {
        return (
            <div className="App">
                <h1>This is Skinet App </h1>
                <button onClick={()=>alert('hello')}>Hello</button>
            </div>
        );
    }
} 

export default App;
