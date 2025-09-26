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

function App() {
  const [count, setCount] = useState(0)

  return (
    <Provider>
      <UnAuthorizedHeader/> 
    </Provider>
  )
}

export default App
