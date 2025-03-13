import './App.css'
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom'
import UserRegistration from './components/UserRegistration'
import AdminLogin from './components/AdminLogin'
import UploadFiles from './components/UploadFiles'
import DataViweing from './components/DataViweing'

function App() {

  return (
  <Router>
    <Routes>
      <Route path="/user-registration" element={<UserRegistration />} />
      <Route path='/admin-login' element={<AdminLogin />} />
      <Route path='/upload-file' element={<UploadFiles />} />
      <Route path='/data-viweing' element={<DataViweing />} />
    </Routes>
  </Router>
  )
}

export default App