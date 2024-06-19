import { useState } from "react"
import { Navigate, To, useNavigate } from "react-router-dom"
  
function useSwitchRoute() {
    const [path, setPath] = useState('')
    const navigate = useNavigate()
  
    const navigateTo = (newPath: string) => {
        setPath(newPath);
        navigate(newPath);
    }
  
    return navigateTo
  }

export {
    useSwitchRoute,
}
