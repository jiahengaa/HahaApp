<template>
    <el-container>
      <el-header>

        <el-col :span="24" class="header">
          <el-col :span="20" class="logo">
            <img src="../assets/chromFXUI.png" alt="哈哈看电影"><span>哈哈看电影</span>
          </el-col>
          <el-col :span="4">
            <ul class="sys-cmd">
              <li cfx-ui-command="minimize"><i class="fa fa-window-minimize"></i></li>
              <li cfx-ui-command="maximize"><i class="fa fa-window-maximize"></i></li>
              <li cfx-ui-command="close"><i class="fa fa-window-close"></i></li>
            </ul>
          </el-col>
          
        </el-col>
        

      </el-header>
        <el-container>
        <el-aside style="width: 200px;">
          <el-menu :default-active="$route.path" @open="handleopen" @close="handleclose" @select="handleselect" unique-opened router>
              <template v-for="(item,index) in $router.options.routes" v-if="!item.hidden">
                <el-submenu v-bind:key="index" :index="index+''" v-if="!item.leaf">
                  <template slot="title"><i :class="item.iconCls"></i>{{item.name}}</template>
                  <el-menu-item v-for="child in item.children"  v-bind:key="child.index" :index="child.path" v-if="!child.hidden">{{child.name}}</el-menu-item>
                </el-submenu>
                <el-menu-item  v-bind:key="index" v-if="item.leaf&&item.children.length>0" :index="item.children[0].path "><i :class="item.iconCls"></i>{{item.children[0].name}}</el-menu-item>
              </template>
            </el-menu>
        </el-aside>
        <el-main>
                <transition>
                  <keep-alive>
                    <router-view v-if="$route.meta.keepAlive">
                      <!-- 这里是会被缓存的视图组件-->
                    </router-view>
                  </keep-alive>
                  
                </transition>
                <transition>
                  <router-view v-if="!$route.meta.keepAlive">
                    <!-- 这里是不被缓存的视图组件-->
                  </router-view>
                </transition>
        </el-main>
      </el-container>
    </el-container>
</template>

<script lang="ts">
import Vue from "vue";
import Component from "vue-class-component";
import SelectCatgory from "@/components/SelectCatgory.vue";
import NoFile from "@/components/NoFile.vue";
import CatgoryTree from "@/components/CatgoryTree.vue";
import FileList from "@/components/FileList.vue";
import PopularActors from "@/components/PopularActors.vue";
import UpcomingMovies from "@/components/UpcomingMovies.vue";

@Component({
  components: {
    SelectCatgory,
    NoFile,
    CatgoryTree,
    FileList,
    PopularActors,
    UpcomingMovies
  }
})
export default class Main extends Vue {
  addDirectories: Array<Object> = [];
  addFiles: Array<Object> = [];
  addMenuFiles: Array<Object> = [];
  treeData: any = [];

  created() {

  }

  mounted() {
    // console.log(`mounted:${this.treeData}`)
  }

  // 更新树形结构数据
  updateTreeData(data: Array<Object>) {
    this.treeData = data;
  }

  reset() {
    this.treeData = [];
  }

  handleopen() {

  }
  handleclose() {

  }
  handleselect() {

  }
}
</script>

<style lang="scss">
$defaultBlue: rgb(30, 30, 30);
$headerColor: rgb(51, 51, 51);
$hoverBlue: rgb(40, 40, 40);
$clickBlue: rgb(57, 57, 88);
$containerBackgroundColor:rgb(116, 88, 88);
$textColor:#d2d8ddce;
$textHoverColor:#b5d4dd;
$textSelectedColor:#9ac9d6;

.el-container {
  background-color: $defaultBlue;
  color: $textHoverColor;
  text-align: center;
  height: 100%;

  .logo {
      font-size: 22px;
      -webkit-app-region: drag;
      text-align: left;

      line-height: 60px;

      img {
        width: 40px;
        float: left;
        margin: 10px 10px 10px 18px;
        -webkit-app-region: drag;
      }
      .txt {
        color: #20a0ff;
        -webkit-app-region: drag;
      }
    }

    .sys-cmd {
      position: absolute;
      top: 0px;
      right: 0px;
      color: #475669;
      display: inline-block;
      vertical-align: top;
      padding: 0px;
      margin-top: 4px;
      cursor: pointer;
      -webkit-app-region: no-drag;
    }
    .sys-cmd li {
      color: #20a0ff;
      display: inline-flex;
      width: 32px;
      background-color: transparent;
      align-items: right;
      justify-content: center;
      transition: all ease-in-out 300ms;
      font-size: 0.8em;
    }
    .sys-cmd li:hover {
      color: violet;
    }
    .sys-cmd li:active {
      color: #c0ccda;
    }

  :hover{
    color: $textHoverColor;
  };

  .el-header {
    background-color: $headerColor;
    -webkit-app-region:drag;
  
  }

  .el-menu {
    background-color: $defaultBlue;
    color: $textColor;
    border-right-width: 0px;
    :hover{
      background-color: $hoverBlue;
    }
    .is-active{
            color:$textSelectedColor !important;
          }
    .el-submenu__title{
      color:$textColor;
    }
    .el-submenu {
        background-color: $defaultBlue;
        color:$textColor;
        .el-menu-item {
          background-color: $defaultBlue;
          color:$textColor;
            .el-submenu {
            background-color: $defaultBlue;
            color:$textColor;
          }
        }
      }
    
    
  }

  .el-main {
    background-color: $containerBackgroundColor;
    margin-left: 0px;
    margin-right: 0px;
    padding-left: 10px;
    padding-right: 10px;
  }
}
</style>


