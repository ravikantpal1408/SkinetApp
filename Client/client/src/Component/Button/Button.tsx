import React from 'react';


function Button() {
    return (
        <div>
             <div onClick={()=>{alert('Hello worl')}} style={{border: '1px solid red', padding: '5px'}}> This is some button</div>
        </div>
    );
  }
  
  export default Button;