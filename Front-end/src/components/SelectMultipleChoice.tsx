import {  useTheme } from '@chakra-ui/react';;
import Select from 'react-select';
import makeAnimated from 'react-select/animated';
import { Platform } from '../hooks/useGames';
import usePlatforms from '../hooks/usePlatforms'
export interface Selected{
  value:number,
  label:string
}
interface Props {
  platforms:Selected[] | null,
  handleMultiChoice: (platforms:Selected[]) => void;
}

const animatedComponents = makeAnimated();

const SelectMultipleChoice = ({platforms, handleMultiChoice}:Props) => {
  const {data} = usePlatforms();
  const theme = useTheme()
  const options = data.map((option:Platform) => ({
    value: option.id,
    label: option.name
  }));
  const handleSelect = (selected: any) => {
    handleMultiChoice(selected)
  };

  const customStyles = {

    control: (provided: any) => ({
      ...provided,
      backgroundColor:  theme.colors.currentColor, // Change the background color here
    }),

    menu: (provided: any) => ({
      ...provided,
      backgroundColor: theme.colors.currentColor, // Change the background color of the list
    }),
    multiValue: (provided: any) => ({
      ...provided,
      backgroundColor: theme.colors.currentColor, // Color of the selected options
      color: theme.colors.currentColor, // Text color of the selected options
    }),
    multiValueLabel: (provided: any) => ({
      ...provided,
      color: theme.colors.currentColor, // Text color of the selected options
    }),
  };
  return (
    <span
      className="d-inline-block"
      data-toggle="popover"
      data-trigger="focus"
      data-content="Please select account(s)"
    >
    <Select 
    styles={customStyles}
      closeMenuOnSelect={true}
      components={animatedComponents}
      defaultValue={[options[0]]}
      isMulti
      options={options}
      value={platforms}
      onChange={handleSelect}
    />
    </span>
  );
}

export default SelectMultipleChoice

