using D7_abstract_classes;
//using D7_ansi_case;
//using D7_ansi_compare;
//using D7_ansi_lookup;
//using D7_arrays;
using D7_bit_operations;
using D7_case_statements;
//using D7_character_types;
using D7_classes;
using D7_concat;
//using D7_currency;
using D7_data_types;
//using D7_datetime;
//using D7_datetime_formatting;
//using D7_exceptions;
//using D7_extract_file_path;
//using D7_file_age;
//using D7_file_rename;
//using D7_file_search;
using D7_fill_char;
//using D7_float_to_strf;
//using D7_for_loops;
//using D7_formatting;
//using D7_free_and_nil;
using D7_free_mem;
using D7_functions;
using D7_get_mem;
using D7_goto;
using D7_inherited;
//using D7_int_to_str;
using D7_interfaces_basic;
using D7_is_operator;
//using D7_math;
//using D7_max;
//using D7_min;
using D7_move_memory;
//using D7_overloads_basic;
using D7_overrides;
//using D7_pointers;
//using D7_position_search;
//using D7_procedures;
using D7_properties_basic;
using D7_realloc_mem;
using D7_records;
using D7_set_exclude;
using D7_set_include;
using D7_set_length;
using D7_set_string;
using D7_sets;
//using D7_str_procedure;
//using D7_string_boundaries;
//using D7_string_conversions;
//using D7_string_list;
//using D7_string_processor;
//using D7_string_utilities;
//using D7_tdatetime;
//using D7_text_append;
//using D7_text_read;
//using D7_text_write;
//using D7_threadvar;
//using D7_tlist;
//using D7_try_blocks;
using D7_with_statement;
using Factory;  
using Objfree;
using Vstatic;

// insert this comment into manually modified code
// -----------------------------------------------
// Manually modified after automatic translation by D2CSharp.
// Modifications by Dr. Detlef Meyer-Eltz, t2t-soft.



namespace Tests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool b = true;
            try
            {
            b = b && D7_abstract_classes.D7_abstract_classesInterface.RunAbstractClassChecks();
            b = b && D7_ansi_case.D7_ansi_caseInterface.RunAnsiCaseChecks();
// not implemented            b = b && D7_ansi_compare.D7_ansi_compareInterface.RunAnsiComparisonChecks();
            //b = b && D7_ansi_lookup.D7_ansi_lookupInterface.RunAnsiLookupChecks();
            //b = b && D7_arrays.D7_arraysInterface.RunArrayChecks();
            b = b && D7_bit_operations.D7_bit_operationsInterface.RunBitOperationChecks();
            b = b && D7_case_statements.D7_case_statementsInterface.RunCaseStatementChecks();
            //b = b && D7_character_types.D7_character_typesInterface.RunCharacterChecks();
            b = b && D7_classes.D7_classesInterface.RunClassChecks();
            b = b && D7_concat.D7_concatInterface.RunConcatenationChecks();
            b = b && D7_currency.D7_currencyInterface.RunCurrencyChecks();
            b = b && D7_data_types.D7_data_typesInterface.RunDataTypeChecks();
            //b = b && D7_datetime.D7_datetimeInterface.RunDateTimeChecks();
            //b = b && D7_datetime_formatting.D7_datetime_formattingInterface.RunDateTimeFormattingChecks();
            //b = b && D7_exceptions.D7_exceptionsInterface.RunExceptionChecks();
// not implemented            b = b && D7_extract_file_path.D7_extract_file_pathInterface.RunExtractFilePathChecks();
            //b = b && D7_file_age.D7_file_ageInterface.RunFileAgeChecks();
            //b = b && D7_file_rename.D7_file_renameInterface.RunFileRenameChecks();
            //b = b && D7_file_search.D7_file_searchInterface.RunFileSearchChecks();
            b = b && D7_fill_char.D7_fill_charInterface.RunFillCharChecks();
 // not implemented           b = b && D7_float_to_strf.D7_float_to_strfInterface.RunFloatToStrFChecks();
            b = b && D7_for_loops.D7_for_loopsInterface.RunForLoopChecks();
 // not implementd           b = b && D7_formatting.D7_formattingInterface.RunFormattingChecks();
            b = b && D7_free_and_nil.D7_free_and_nilInterface.RunFreeAndNilChecks();
            b = b && D7_free_mem.D7_free_memInterface.RunFreeMemChecks();
            b = b && D7_functions.D7_functionsInterface.RunFunctionChecks();
            b = b && D7_get_mem.D7_get_memInterface.RunGetMemChecks();
            b = b && D7_goto.D7_gotoInterface.RunGotoChecks();
            b = b && D7_inherited.D7_inheritedInterface.RunInheritedChecks();
            b = b && D7_int_to_str.D7_int_to_strInterface.RunIntToStrChecks();
            b = b && D7_interfaces_basic.D7_interfaces_basicInterface.RunBasicInterfaceChecks();
            b = b && D7_is_operator.D7_is_operatorInterface.RunIsOperatorChecks();
            //b = b && D7_math.D7_mathInterface.RunMathChecks();
            //b = b && D7_max.D7_maxInterface.RunMaxChecks();
            //b = b && D7_min.D7_minInterface.RunMinChecks();
            b = b && D7_move_memory.D7_move_memoryInterface.RunMoveChecks();
            b = b && D7_overloads_basic.D7_overloads_basicInterface.RunBasicOverloadChecks();
            b = b && D7_overrides.D7_overridesInterface.RunOverrideChecks();
            //b = b && D7_pointers.D7_pointersInterface.RunPointerChecks();
// not implemented            b = b && D7_position_search.D7_position_searchInterface.RunPositionChecks();
            b = b && D7_procedures.D7_proceduresInterface.RunProcedureChecks();
            b = b && D7_properties_basic.D7_properties_basicInterface.RunBasicPropertyChecks();
            b = b && D7_realloc_mem.D7_realloc_memInterface.RunReallocMemChecks();
            b = b && D7_records.D7_recordsInterface.RunRecordChecks();
            b = b && D7_set_exclude.D7_set_excludeInterface.RunSetExcludeChecks();
            b = b && D7_set_include.D7_set_includeInterface.RunSetIncludeChecks();
            b = b && D7_set_length.D7_set_lengthInterface.RunSetLengthChecks();
            b = b && D7_set_string.D7_set_stringInterface.RunSetStringChecks();
            b = b && D7_sets.D7_setsInterface.RunSetChecks();
            //b = b && D7_str_procedure.D7_str_procedureInterface.RunStrProcedureChecks();
            //b = b && D7_string_boundaries.D7_string_boundariesInterface.RunStringBoundaryChecks();
            //b = b && D7_string_conversions.D7_string_conversionsInterface.RunStringConversionChecks();
            //b = b && D7_string_list.D7_string_listInterface.RunStringListChecks();
            b = b && D7_string_processor.D7_string_processorInterface.RunStringProcessorChecks();
            //b = b && D7_string_utilities.D7_string_utilitiesInterface.RunStringUtilityChecks();
            //b = b && D7_tdatetime.D7_tdatetimeInterface.RunTDateTimeChecks();
            //b = b && D7_text_append.D7_text_appendInterface.RunAppendChecks();
            //b = b && D7_text_read.D7_text_readInterface.RunTextReadChecks();
            //b = b && D7_text_write.D7_text_writeInterface.RunTextWriteChecks();
            //b = b && D7_threadvar.D7_threadvarInterface.RunThreadVarChecks();
            //b = b && D7_tlist.D7_tlistInterface.RunTListChecks();
            //b = b && D7_try_blocks.D7_try_blocksInterface.RunTryBlockChecks();
            b = b && D7_with_statement.D7_with_statementInterface.RunWithStatementChecks();
            b = b && ObjfreeInterface.TestObjFreeAll();
            b = b && FactoryInterface.testfactory();    
            b = b && VstaticInterface.TestVStatic();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            if (b)
                b = true; // for breakpoint
            else
                b = true; // for breakpoint
        }
    }
}
