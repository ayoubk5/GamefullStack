import { Button, HStack, Image, Text, Menu, MenuButton, MenuItem, MenuList } from "@chakra-ui/react";
import logo from "../assets/logo.webp";
import ColorModeSwitch from "./ColorModeSwitch";
import SearchInput from "./SearchInput";
import { FiSettings, FiPlus } from "react-icons/fi";
import { Link, useNavigate } from 'react-router-dom'
interface Props{
  onSearch:(searchText:string) => void
}
const NavBar = ({onSearch}:Props) => {
  const navigate = useNavigate();
  const handleNavigate=()=>{
    navigate("/")
  }
  return (
    <HStack  padding="10px">
      <Image src={logo} boxSize="50px" onClick={handleNavigate} cursor={"pointer"}/>
      <SearchInput onSearch={onSearch}/>

      <Menu>
        <MenuButton as={Button} variant="link" ><FiSettings/></MenuButton>
        <MenuList>
            <Link to="createGame">
          <MenuItem>
          <HStack>
            <FiPlus/>
            <Text>
            Add Game
            </Text>
          </HStack>
          </MenuItem>
            </Link>
        </MenuList>
    </Menu>
      <ColorModeSwitch />
    </HStack>
  );
};

export default NavBar;
