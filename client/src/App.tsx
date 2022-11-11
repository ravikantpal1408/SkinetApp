import { createTheme, CssBaseline, ThemeProvider } from '@mui/material';
import { Container } from '@mui/system';
import React, { useState } from 'react';
import Catalog from './Components/Products/Catalog.component';
import Header from './Layout/Header/Header';

function App() {
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

  function handleThemeChange() {
    console.log('checking state of darkMode', !darkMode)
    setDarkMode(!darkMode);
  }
  return (
    <React.Fragment>
      <ThemeProvider theme={theme}>
        <CssBaseline />
        <Header darkMode={darkMode} handleThemeChange={handleThemeChange} />
        <Container>
           <Catalog />

       </Container>
      </ThemeProvider>

    </React.Fragment>
  )
}


export default App;
