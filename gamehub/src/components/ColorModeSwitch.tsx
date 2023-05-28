import { HStack, Switch, Text, useColorMode } from "@chakra-ui/react";

const ColorModeSwitch = () => {
  const { toggleColorMode } = useColorMode();
  return (
    <HStack>
      <Switch
        colorScheme="green"
        onChange={toggleColorMode}
      />
      <Text whiteSpace="nowrap">Light Mode</Text>
    </HStack>
  );
};

export default ColorModeSwitch;
