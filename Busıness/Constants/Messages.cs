using Core.Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string SampleMessageForReference = "SampleMessageForReference!";
        public static string ProjectCreated = "Project is created succesfully!";
        public static string projectUpdated= "Project is updated successfuly!";
        public static string AuthorizationDenied = "You have not authorised for this operation!";
        public static string AccessTokenCreated = "Access Token Created!";
        public static string UserAlreadyExists = "User Already Exists!";
        public static string SuccessfulLogin = "Successful Login!";
        public static string PasswordError = "Password Error!";
        public static string UserNotFound = "User not found!";
        public static string UserRegistered = "User registered!";
        public static string UserDetailAdded = "User detail added succesfully!";
        public static string UserDetailDeleted = "User detail deleted succesfully!";
        public static string UserDetailUpdated = "User detail updated succesfully!";
        public static string UserAddedToProject = "User added to project succesfully!";
        public static string UserDeletedFromProject= "User deleted from this project!";
        public static string UserProjectUpdated = "UserProject updated succesfully!";
        public static string ScoreAdded= " Score Table entry saved successfully!";
        public static string CustomerAdded= "New customer added successfully!";
        public static string CustomerUpdated= "Customer informations updated succesfully!";
        public static string CustomerDeleted = "Customer Deleted successfully!";
        public static string CustomerNotExist= "Customer not exists!";
        public static string CheckProjectAssigner="Project assigner is not exist in users!";
        public static string CheckProjectLead="Project leader is not exist in users!";
        public static string StartDateOfProjectError= "project for the past cannot be opened!";
        public static string UserAllreadyExistInProject= "user to be added  is already exist in this project!";
        public static string ProjectNameExist= "Project name is allready exists!";
        public static string ProjectIsNotExists= "Project is not exists!";
        public static string ScoreUpdated= "Score updated!";
        public static string UserProjectNotExist= "User project does not exist!";
        public static string AllreadyHaveScoreInput="There is already a score input!";
        public static string UserDoesntMatchWithProject = "this user not has been involved in that project!";
        public static string UserDetailExist= "User detail exists!";
        public static string ScoreTableInputIsNotActive= "This scoring record is not used activly!";
        public static string JobTitleAdded= "job title added!";
        public static string jobTitleDeleted= "job title deleted!";
        public static string jobTitleUpdated= "job title updated!";
        public static string FieldAdded= "field Added!";
        public static string FieldDeleted= "field deleted!";
        public static string FieldUpdated= "field updated!";
        public static string DepartmentAdded= "department added!";
        public static string DepartmentDeleted= "deparment deleted!";
        public static string DepartmentUpdated= "department updated!";
        public static string FieldNotExists= "field not exists!";
        public static string FieldIsNotActive= "field is not active!";
        public static string DepartmentNotExists= "department is not exists!";
        public static string DepartmentIsNotActive= "deparment is not active!";
        public static string JobTitleIsNotActive= "job title is not active!";
        public static string JobTitleNotExists="job title is not exists!";
        public static string NationalIdentityCantDuplicate="National Identity can not duplicate!";
        public static string jobTitleNameExists="job title name is allready exist!";
        public static string DepartmentNameExists="department name is allready exist!";
        public static string fieldNameIsExist="field name is allready exist!";
        public static string DepartmentInformationsNotCoherant="department informations are not coherant";
        public static string SomethingWentWrong="something went wrong";
    }
}
