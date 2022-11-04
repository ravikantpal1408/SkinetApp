import { ThemeProvider } from '@emotion/react';
import { Container, createTheme, CssBaseline } from '@mui/material';
import axios from 'axios';
import React, { useEffect, useState } from 'react';
import Header from './Layout/Header';
import Catalog from './Components/Catalog/Catalog';

function App() {
  const [data, setData] = useState<any[]>([]);
  const [darkMode, setDarkMode] = useState(false);
  const paletteType  = darkMode ? 'dark' : 'light'
  const theme = createTheme({
    palette: {
      mode: paletteType,
      background: {
        default: paletteType === 'light' ? '#eaeaea' : '#121212'
      }
    }
  })

  
  useEffect(() => {
    axios.get('https://localhost:5001/api/Product/products').then(res => {
      setData(res.data);
    });
  }, []);

  function handleThemeChange() {
    setDarkMode(!darkMode);
  }

  return <>
    <ThemeProvider theme={theme}>
       <CssBaseline />
       <Header darkMode={darkMode} handleThemeChange={handleThemeChange} />
       <Container>
           <Catalog />

       </Container>
     </ThemeProvider>
  </>
}

export default App;
