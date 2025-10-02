import { Component, useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import './index.css'
import { Provider } from "./components/ui/provider"
import { Demo } from './test'
import {DashBoard} from './Pages/Dashboard'
import AuthorizedDrawer from './components/layout/SideDrawer'
import UnAuthorizedHeader from './components/layout/UnAuthorizedHeader'
import UnAuthorizedHome from './Pages/Home'
import RegisterPage from './Pages/Register'
import LoginPage from './Pages/LoginPage'
import AuthorizedHome from './Pages/AuthorizedHome'
import ShoppingCartPage from './Pages/ShoppingCart'
import { BrowserRouter, Routes } from 'react-router'
import { Route } from 'react-router'
import EmployeePage from './Pages/EmployeePage'

function App() {
  const [count, setCount] = useState(0)

  return (
    <BrowserRouter>
      <Provider>
        <div>
          <Routes>
            <Route path={"/"} element={<UnAuthorizedHome/>}/>
            <Route path= {"/Register"} element={<RegisterPage/>}/>
            <Route path={"/Login"} element={<LoginPage/>}/>
            <Route path={"/AuthorizedUser"} element={ <AuthorizedHome/>}/>
            <Route path="/Employee" element={<EmployeePage/>}/>
          </Routes>
        </div>
      </Provider>
    </BrowserRouter>
  )
}

export default App
