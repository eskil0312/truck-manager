import React from 'react';
import  styles from './styles.module.scss';
import Toolbar from './components/Toolbar';
import { createMuiTheme } from "@material-ui/core/styles";
import { ThemeProvider } from "@material-ui/styles";

const theme = createMuiTheme();


const Layout = (props) => {
    return(
        <div className={styles.Layout}>
            <ThemeProvider theme={theme}>
                <Toolbar/>
                {props.children}
            </ThemeProvider>

        </div>
        
      
    )
}
export default Layout;