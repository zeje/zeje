
//选择部门
function ShowDepartment(_PopType, _Params) {
    if (window.parent) {
        var popType = _PopType;
        var ifmId = window.frameElement && window.frameElement.id || '';
        window.parent.showMyWindow(popType, "选择部门", "/Pop/Department" + (_Params == undefined ? "" : _Params), 800, 600, ifmId);
    }
    else {
        alert("请在框架中使用该功能！");
    }
}

//选择部门
function ShowDepartmentSingle(_PopType) {
    if (window.parent) {
        var popType = _PopType;
        var ifmId = window.frameElement && window.frameElement.id || '';
        window.parent.showMyWindow(popType, "选择部门", "/Pop/DepartmentSingle", 800, 600, ifmId);
    }
    else {
        alert("请在框架中使用该功能！");
    }
}
//选择职务
function ShowPositionLevel(_PopType) {
    if (window.parent) {
        var popType = _PopType;
        var ifmId = window.frameElement && window.frameElement.id || '';
        window.parent.showMyWindow(popType, "选择职务", "/Pop/PositionLevel", 800, 600, ifmId);
    }
    else {
        alert("请在框架中使用该功能！");
    }
}
//选择职位
function ShowPosition(_PopType) {
    if (window.parent) {
        var popType = _PopType;
        var ifmId = window.frameElement && window.frameElement.id || '';
        window.parent.showMyWindow(popType, "选择职位", "/Pop/Position", 800, 600, ifmId);
    }
    else {
        alert("请在框架中使用该功能！");
    }
}
//选择城市
function ShowCity(_PopType, _Rename) {
    if (window.parent) {
        var popType = _PopType;
        var ifmId = window.frameElement && window.frameElement.id || '';
        window.parent.showMyWindow(popType, _Rename ? _Rename : "选择城市", "/Pop/City", 800, 350, ifmId);
    }
    else {
        alert("请在框架中使用该功能！");
    }
}
//选择省份
function ShowProvince(_PopType, _Rename) {
    if (window.parent) {
        var popType = _PopType;
        var ifmId = window.frameElement && window.frameElement.id || '';
        window.parent.showMyWindow(popType, _Rename ? _Rename : "选择省份", "/Pop/Province", 800, 350, ifmId);
    }
    else {
        alert("请在框架中使用该功能！");
    }
}
//选择绩效结果
function ShowPerformance(_PopType, _Rename) {
    if (window.parent) {
        var popType = _PopType;
        var ifmId = window.frameElement && window.frameElement.id || '';
        window.parent.showMyWindow(popType, "选择绩效结果", "/Pop/Performance", 500, 400, ifmId, true, false, true);
    }
    else {
        alert("请在框架中使用该功能！");
    }
}

//人才检索查询历史记录弹框
function ShowBasicHistory(_PopType, TalentCode, _Rename) {
    if (window.parent) {
        var popType = _PopType;
        var ifmId = window.frameElement && window.frameElement.id || '';
        window.parent.showMyWindow(popType, "基本资料历史数据", "/Pop/BasicHistory?code=" + TalentCode, 900, 600, ifmId, true, false, true);
    }
    else {
        alert("请在框架中使用该功能！");
    }
}
//上传头像
function ShowUpLoadPic(_PopType, TalentCode, _Rename) {
    if (window.parent) {
        var popType = _PopType;
        var ifmId = window.frameElement && window.frameElement.id || '';
        window.parent.showMyWindow(popType, "上传头像", "/Pop/UpLoadPic" + "?talentCode=" + TalentCode, 620, 420, ifmId);
    }
    else {
        alert("请在框架中使用该功能！");
    }
}
//上传文件—Talent
function ShowUpLoadTalentFile(_PopType, TalentCode, UpLoadTalentType, _Rename) {
    if (window.parent) {
        var popType = _PopType;
        var ifmId = window.frameElement && window.frameElement.id || '';
        window.parent.showMyWindow(popType, "上传文件", "/Pop/UpLoadTalentFile" + "?talentCode=" + TalentCode + "&tft=" + UpLoadTalentType, 620, 420, ifmId);
    }
    else {
        alert("请在框架中使用该功能！");
    }
}
//选择负责人
function ShowLeader(_PopType) {
    if (window.parent) {
        var popType = _PopType;
        var ifmId = window.frameElement && window.frameElement.id || '';
        window.parent.showMyWindow(popType, "选择负责人", "/Pop/Leader", 610, 510, ifmId);
    }
    else {
        alert("请在框架中使用该功能！");
    }
}
//选择共享人
function ShowPersons(_PopType) {
    if (window.parent) {
        var popType = _PopType;
        var ifmId = window.frameElement && window.frameElement.id || '';
        window.parent.showMyWindow(popType, "选择共享人", "/Pop/Persons", 610, 510, ifmId);
    }
    else {
        alert("请在框架中使用该功能！");
    }
}
//新增目标(修改目标)
function AddPool(_PopType, id, pid) {
    if (window.parent) {
        var popType = _PopType;
        var ifmId = window.frameElement && window.frameElement.id || '';
        window.parent.showMyWindow(popType, "新增发展目标", "/tpl_Pool/AddPoolDB/" + id + "/" + pid, 400, 250, ifmId);
    }
    else {
        alert("请在框架中使用该功能！");
    }
}
//新增项
function AddPoolCompetency(_PopType, id, pid) {
    if (window.parent) {
        var popType = _PopType;
        var ifmId = window.frameElement && window.frameElement.id || '';
        window.parent.showMyWindow(popType, "新增能力素质项", "/tpl_Pool/AddPoolCompetency/" + id + "/" + pid, 400, 250, ifmId);
    }
    else {
        alert("请在框架中使用该功能！");
    }
}
//修改目标(修改目标)
function EditPool(_PopType, id) {
    if (window.parent) {
        var popType = _PopType;
        var ifmId = window.frameElement && window.frameElement.id || '';
        window.parent.showMyWindow(popType, "修改发展目标", "/tpl_Pool/EditPoolDB/" + id, 400, 250, ifmId);
    }
    else {
        alert("请在框架中使用该功能！");
    }
}
//人才检索查询历史记录弹框
function ShowEvlutionPersonEdit(_PopType, id) {
    if (window.parent) {
        var popType = _PopType;
        var ifmId = window.frameElement && window.frameElement.id || '';
        window.parent.showMyWindow(popType, "评估修改", "/Pop/ShowEvlutionPersonEdit?evalutionId=" + id, 500, 300, ifmId, true, false, true);
    }
    else {
        alert("请在框架中使用该功能！");
    }
}
//增加角色部门
function AddRoleDep(_PopType, id, pid) {
    if (window.parent) {
        var popType = _PopType;
        var ifmId = window.frameElement && window.frameElement.id || '';
        window.parent.showMyWindow(popType, "角色设置查看部门", "/SysRole/AddRoleDep/" + id, 610, 473, ifmId);
    }
    else {
        alert("请在框架中使用该功能！");
    }
}
//新增角色用户
function AddRoleUser(_PopType, id, pid) {
    if (window.parent) {
        var popType = _PopType;
        var ifmId = window.frameElement && window.frameElement.id || '';
        window.parent.showMyWindow(popType, "角色增加用户", "/SysRole/AddRoleUser/" + id, 610, 473, ifmId);
    }
    else {
        alert("请在框架中使用该功能！");
    }
}
//编辑角色用户
function EditRoleUser(_PopType, id, pid) {
    if (window.parent) {
        var popType = _PopType;
        var ifmId = window.frameElement && window.frameElement.id || '';
        window.parent.showMyWindow(popType, "角色编辑用户", "/SysRole/EditRoleUser/" + id, 610, 473, ifmId);
    }
    else {
        alert("请在框架中使用该功能！");
    }
}
//查看用户所属角色
function ViewUserRoles(_PopType, id, pid) {
    if (window.parent) {
        var popType = _PopType;
        var ifmId = window.frameElement && window.frameElement.id || '';
        window.parent.showMyWindow(popType, "查看用户所属角色", "/SysPerson/ViewRoles/" + id, 610, 400, ifmId);
    }
    else {
        alert("请在框架中使用该功能！");
    }
}
function ClearValue(ProType, id, name) {
    if (window.parent) {
        var returnValue = {};
        returnValue.PopType = ProType;
        var row = [{ Id: id, Name: name }];
        returnValue.row = row;
        window.parent.hideMyWindow(returnValue);
    }
}